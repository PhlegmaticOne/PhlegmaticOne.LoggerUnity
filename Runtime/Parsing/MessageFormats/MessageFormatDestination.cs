using System;
using System.Collections.Generic;
using System.Text;
using OpenMyGame.LoggerUnity.Runtime.Base;
using OpenMyGame.LoggerUnity.Runtime.Parsing.Models;
using OpenMyGame.LoggerUnity.Runtime.Properties.Log.Base;

namespace OpenMyGame.LoggerUnity.Runtime.Parsing.MessageFormats
{
    internal class MessageFormatDestination : IMessageFormat
    {
        private readonly MessagePart[] _messageParts;
        private readonly Dictionary<string, ILogFormatProperty> _formatProperties;

        public MessageFormatDestination(
            MessagePart[] messageParts, 
            Dictionary<string, ILogFormatProperty> formatProperties)
        {
            _messageParts = messageParts;
            _formatProperties = formatProperties;
        }
        
        public string Render(LogMessage logMessage, in Span<object> parameters)
        {
            var logBuilder = new StringBuilder();

            foreach (var messagePart in _messageParts)
            {
                var renderMessagePart = Render(messagePart, logMessage, parameters);
                logBuilder.Append(renderMessagePart);
            }
            
            return logBuilder.ToString();
        }
        
        private ReadOnlySpan<char> Render(in MessagePart messagePart, LogMessage message, in Span<object> parameters)
        {
            messagePart.SplitParameterToValueAndFormat(out var parameterValue, out _);
            var property = _formatProperties.GetValueOrDefault(parameterValue.ToString());
            return property is null ? parameterValue : property.GetValue(in messagePart, message, parameters);
        }
    }
}