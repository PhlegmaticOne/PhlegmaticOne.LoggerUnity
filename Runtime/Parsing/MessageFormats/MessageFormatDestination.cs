using System;
using System.Collections.Generic;
using System.Text;
using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Parameters.Log.Base;
using OpenMyGame.LoggerUnity.Parsing.Models;

namespace OpenMyGame.LoggerUnity.Parsing.MessageFormats
{
    internal class MessageFormatDestination : IMessageFormat
    {
        private readonly MessagePart[] _messageParts;
        private readonly Dictionary<string, ILogFormatParameter> _logFormatParameters;

        public MessageFormatDestination(
            MessagePart[] messageParts, 
            Dictionary<string, ILogFormatParameter> logFormatParameters)
        {
            _messageParts = messageParts;
            _logFormatParameters = logFormatParameters;
        }
        
        public string Render(LogMessage logMessage, Span<object> parameters)
        {
            var logBuilder = new StringBuilder();

            foreach (var messagePart in _messageParts)
            {
                var renderMessagePart = Render(messagePart, logMessage, parameters);
                logBuilder.Append(renderMessagePart);
            }
            
            return logBuilder.ToString();
        }
        
        private ReadOnlySpan<char> Render(MessagePart messagePart, LogMessage message, Span<object> parameters)
        {
            messagePart.SplitParameterToValueAndFormat(out var parameterValue, out _);
            var property = _logFormatParameters.GetValueOrDefault(parameterValue.ToString());
            return property is null ? parameterValue : property.GetValue(messagePart, message, parameters);
        }
    }
}