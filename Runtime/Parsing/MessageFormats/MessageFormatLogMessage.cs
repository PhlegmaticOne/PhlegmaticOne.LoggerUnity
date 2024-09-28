using System;
using System.Collections.Generic;
using System.Text;
using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Parameters.Message.Base;
using OpenMyGame.LoggerUnity.Parameters.Message.Serializing;
using OpenMyGame.LoggerUnity.Parsing.Models;
using OpenMyGame.LoggerUnity.Tagging;

namespace OpenMyGame.LoggerUnity.Parsing.MessageFormats
{
    internal class MessageFormatLogMessage : IMessageFormat
    {
        private const char SerializeParameterPrefix = '@';
        
        private readonly MessagePart[] _messageParts;
        private readonly Dictionary<Type, IMessageFormatParameter> _messageFormatParameters;
        private readonly IMessageFormatParameterSerializer _parameterSerializer;

        public MessageFormatLogMessage(
            MessagePart[] messageParts, 
            Dictionary<Type, IMessageFormatParameter> messageFormatParameters,
            IMessageFormatParameterSerializer parameterSerializer)
        {
            _messageParts = messageParts;
            _messageFormatParameters = messageFormatParameters;
            _parameterSerializer = parameterSerializer;
        }
        
        public string Render(LogMessage logMessage, in Span<object> parameters)
        {
            if (_messageParts.Length == 0)
            {
                return string.Empty;
            }
            
            var logBuilder = new StringBuilder();
            var currentParameterIndex = -1;

            foreach (var messagePart in _messageParts)
            {
                var renderMessagePart = Render(logMessage, messagePart, parameters, ref currentParameterIndex);
                logBuilder.Append(renderMessagePart);
            }
            
            return logBuilder.ToString();
        }

        private ReadOnlySpan<char> Render(
            LogMessage message, in MessagePart messagePart, in Span<object> parameters, ref int currentParameterIndex)
        {
            messagePart.SplitParameterToValueAndFormat(out var parameterValue, out var format);
            
            if (!messagePart.IsParameter || parameters.Length == 0)
            {
                return parameterValue;
            }

            var parameter = GetCurrentParameter(in parameters, ref currentParameterIndex);
            ProcessTag(message, parameterValue, parameter);
            return RenderParameter(parameter, parameterValue, format);
        }

        private ReadOnlySpan<char> RenderParameter(
            object parameter, in ReadOnlySpan<char> parameterValue, in ReadOnlySpan<char> format)
        {
            var type = parameter.GetType();

            if (_messageFormatParameters.TryGetValue(type, out var property))
            {
                return property.Render(parameter, in format);
            }

            if (parameterValue[0] == SerializeParameterPrefix)
            {
                return _parameterSerializer.Serialize(parameter);
            }
            
            return parameter.ToString();
        }

        private static void ProcessTag(
            LogMessage logMessage, in ReadOnlySpan<char> parameterValue, object parameter)
        {
            if (parameterValue.Equals(LogWithTag.PropertyKey, StringComparison.OrdinalIgnoreCase))
            {
                logMessage.SetTag((LogTag)parameter);
            }
        }

        private static object GetCurrentParameter(in Span<object> parameters, ref int currentParameterIndex)
        {
            currentParameterIndex = (currentParameterIndex + 1) % parameters.Length;
            return parameters[currentParameterIndex];
        }
    }
}