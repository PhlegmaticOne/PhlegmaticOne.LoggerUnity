using System;
using System.Collections.Generic;
using System.Linq;
using OpenMyGame.LoggerUnity.Runtime.Messages;
using OpenMyGame.LoggerUnity.Runtime.Parsing;
using OpenMyGame.LoggerUnity.Runtime.Properties.Base;

namespace OpenMyGame.LoggerUnity.Runtime.Properties.Container
{
    public class LogMessagePartRendererFormatProperties : ILogMessagePartRenderer
    {
        private readonly Dictionary<string, ILogFormatProperty> _formatProperties;

        public LogMessagePartRendererFormatProperties(IEnumerable<ILogFormatProperty> formatProperties)
        {
            _formatProperties = formatProperties.ToDictionary(x => x.Key, x => x);
        }
        
        public ReadOnlySpan<char> Render(in MessagePart messagePart, LogMessage message)
        {
            messagePart.SplitParameterToValueAndFormat(out var parameterValue, out _);
            var property = _formatProperties.GetValueOrDefault(parameterValue.ToString());
            return property is null ? parameterValue : property.GetValue(in messagePart, message);
        }
    }
}