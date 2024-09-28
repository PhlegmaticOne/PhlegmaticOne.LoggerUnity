using System;
using System.Diagnostics;
using OpenMyGame.LoggerUnity.Attributes;
using OpenMyGame.LoggerUnity.Extensions;
using OpenMyGame.LoggerUnity.Parsing.Infrastructure;

namespace OpenMyGame.LoggerUnity.Base
{
    public partial class LogMessage
    {
        [Conditional("UNITY_LOGGING_ENABLED")]
        public void Log(string format)
        {
            if (!ProcessStartLogMessage(format))
            {
                return;
            }
            
            if (Tag is null)
            {
                _logger.LogMessage(this, Span<object>.Empty);
                return;
            }

            AddTagToFormat();
            LogPrivate(Tag);
        }
        
        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public void Log<T>(string format, T parameter1)
        {
            if (!ProcessStartLogMessage(format))
            {
                return;
            }
            
            if (Tag is null)
            {
                LogPrivate(parameter1);
                return;
            }

            AddTagToFormat();
            LogPrivate(Tag, parameter1);
        }
        
        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public void Log<T1, T2>(string format, T1 parameter1, T2 parameter2)
        {
            if (!ProcessStartLogMessage(format))
            {
                return;
            }
            
            if (Tag is null)
            {
                LogPrivate(parameter1, parameter2);
                return;
            }

            AddTagToFormat();
            LogPrivate(Tag, parameter1, parameter2);
        }
        
        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public void Log<T1, T2, T3>(string format, T1 parameter1, T2 parameter2, T3 parameter3)
        {
            if (!ProcessStartLogMessage(format))
            {
                return;
            }
            
            if (Tag is null)
            {
                LogPrivate(parameter1, parameter2, parameter3);
                return;
            }

            AddTagToFormat();
            LogPrivate(Tag, parameter1, parameter2, parameter3);
        }
        
        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public void Log(string format, params object[] parameters)
        {
            if (!ProcessStartLogMessage(format))
            {
                return;
            }
            
            if (Tag is null)
            {
                _logger.LogMessage(this, parameters);
                return;
            }

            AddTagToFormat();
            _logger.LogMessage(this, parameters.PrependValue(Tag));
        }
        
        private void LogPrivate<T>(T parameter1)
        {
            var propertiesInlineArray = new PropertyInlineArray1();
            var parameters = propertiesInlineArray.AsSpan();
            parameters[0] = parameter1;
            _logger.LogMessage(this, parameters);
        }
        
        private void LogPrivate<T1, T2>(T1 parameter1, T2 parameter2)
        {
            var propertiesInlineArray = new PropertyInlineArray2();
            var parameters = propertiesInlineArray.AsSpan();
            parameters[0] = parameter1;
            parameters[1] = parameter2;
            _logger.LogMessage(this, parameters);
        }
        
        private void LogPrivate<T1, T2, T3>(T1 parameter1, T2 parameter2, T3 parameter3)
        {
            var propertiesInlineArray = new PropertyInlineArray3();
            var parameters = propertiesInlineArray.AsSpan();
            parameters[0] = parameter1;
            parameters[1] = parameter2;
            parameters[2] = parameter3;
            _logger.LogMessage(this, parameters);
        }
        
        private void LogPrivate<T1, T2, T3, T4>(T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4)
        {
            var propertiesInlineArray = new PropertyInlineArray4();
            var parameters = propertiesInlineArray.AsSpan();
            parameters[0] = parameter1;
            parameters[1] = parameter2;
            parameters[2] = parameter3;
            parameters[3] = parameter4;
            _logger.LogMessage(this, parameters);
        }
        
        private void AddTagToFormat()
        {
            _format = _logger.LogTagProvider.AddTagToFormat(_format);
        }

        private bool ProcessStartLogMessage(string format)
        {
            _format = format;
            return _logger is not null && _logger.IsEnabled && !string.IsNullOrEmpty(format);
        }
    }
}