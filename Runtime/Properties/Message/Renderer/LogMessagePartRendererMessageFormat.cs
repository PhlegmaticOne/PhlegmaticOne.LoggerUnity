using System;
using System.Collections.Generic;
using OpenMyGame.LoggerUnity.Runtime.Base;
using OpenMyGame.LoggerUnity.Runtime.Parsing.Base;
using OpenMyGame.LoggerUnity.Runtime.Parsing.Models;
using OpenMyGame.LoggerUnity.Runtime.Properties.Message.Base;

namespace OpenMyGame.LoggerUnity.Runtime.Properties.Message.Renderer
{
    public class LogMessagePartRendererMessageFormat : ILogMessagePartRenderer
    {
        private readonly object[] _parameters;
        private readonly Dictionary<Type, IMessageFormatProperty> _formatProperties;

        private int _currentParameterIndex;

        public LogMessagePartRendererMessageFormat(
            object[] parameters, 
            Dictionary<Type, IMessageFormatProperty> formatProperties)
        {
            _parameters = parameters;
            _formatProperties = formatProperties;
            _currentParameterIndex = -1;
        }
        
        public ReadOnlySpan<char> Render(in MessagePart messagePart, LogMessage message)
        {
            messagePart.SplitParameterToValueAndFormat(out var parameterValue, out var format);
            
            if (!messagePart.IsParameter || _parameters.Length == 0)
            {
                return parameterValue;
            }

            var parameter = GetCurrentParameter();
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

        private object GetCurrentParameter()
        {
            _currentParameterIndex = (_currentParameterIndex + 1) % _parameters.Length;
            var parameter = _parameters[_currentParameterIndex];
            return parameter;
        }
    }
}