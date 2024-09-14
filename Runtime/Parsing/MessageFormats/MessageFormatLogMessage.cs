using System;
using System.Collections.Generic;
using System.Text;
using OpenMyGame.LoggerUnity.Runtime.Base;
using OpenMyGame.LoggerUnity.Runtime.Parsing.Models;
using OpenMyGame.LoggerUnity.Runtime.Properties.Message.Base;

namespace OpenMyGame.LoggerUnity.Runtime.Parsing.MessageFormats
{
    public class MessageFormatLogMessage : IMessageFormat
    {
        private readonly MessagePart[] _messageParts;
        private readonly Dictionary<Type, IMessageFormatProperty> _formatProperties;

        public MessageFormatLogMessage(
            MessagePart[] messageParts, 
            Dictionary<Type, IMessageFormatProperty> formatProperties)
        {
            _messageParts = messageParts;
            _formatProperties = formatProperties;
        }
        
        public string Render(LogMessage logMessage, in Span<object> parameters)
        {
            var logBuilder = new StringBuilder();
            var currentParameterIndex = -1;

            foreach (var messagePart in _messageParts)
            {
                var renderMessagePart = Render(messagePart, parameters, ref currentParameterIndex);
                logBuilder.Append(renderMessagePart);
            }
            
            return logBuilder.ToString();
        }

        private ReadOnlySpan<char> Render(
            in MessagePart messagePart, in Span<object> parameters, ref int currentParameterIndex)
        {
            messagePart.SplitParameterToValueAndFormat(out var parameterValue, out var format);
            
            if (!messagePart.IsParameter || parameters.Length == 0)
            {
                return parameterValue;
            }

            var parameter = GetCurrentParameter(in parameters, ref currentParameterIndex);
            return RenderParameter(parameter, format);
        }

        private ReadOnlySpan<char> RenderParameter(object parameter, in ReadOnlySpan<char> format)
        {
            var type = parameter.GetType();

            if (_formatProperties.TryGetValue(type, out var property))
            {
                return property.Render(parameter, in format);
            }
            
            return parameter.ToString();
        }

        private static object GetCurrentParameter(in Span<object> parameters, ref int currentParameterIndex)
        {
            currentParameterIndex = (currentParameterIndex + 1) % parameters.Length;
            var parameter = parameters[currentParameterIndex];
            return parameter;
        }
    }
}