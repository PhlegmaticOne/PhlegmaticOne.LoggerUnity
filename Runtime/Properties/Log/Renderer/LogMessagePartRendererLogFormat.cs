using System;
using System.Collections.Generic;
using System.Linq;
using OpenMyGame.LoggerUnity.Runtime.Base;
using OpenMyGame.LoggerUnity.Runtime.Parsing.Base;
using OpenMyGame.LoggerUnity.Runtime.Parsing.Models;
using OpenMyGame.LoggerUnity.Runtime.Properties.Log.Base;

namespace OpenMyGame.LoggerUnity.Runtime.Properties.Log.Renderer
{
    public class LogMessagePartRendererLogFormat : ILogMessagePartRenderer
    {
        private readonly Dictionary<string, ILogFormatProperty> _formatProperties;

        public LogMessagePartRendererLogFormat(IEnumerable<ILogFormatProperty> formatProperties)
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