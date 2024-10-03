using System;
using System.Diagnostics;
using OpenMyGame.LoggerUnity.Attributes;
using OpenMyGame.LoggerUnity.Extensions;
using OpenMyGame.LoggerUnity.Parsing.Infrastructure;

namespace OpenMyGame.LoggerUnity.Base
{
    public partial class LogMessage
    {
        [Conditional(LoggerStaticData.ConditionalName)]
        public void Log(string format)
        {
            if (!CanLogMessage(format))
            {
                return;
            }
            
            if (Tag is null)
            {
                RenderMessage(format, Span<object>.Empty);
                _logger.LogMessage(this, Span<object>.Empty);
                return;
            }

            LogPrivate(AddTagToFormat(format), Tag);
        }
        
        [MessageTemplateFormatMethod("format")]
        [Conditional(LoggerStaticData.ConditionalName)]
        public void Log<T>(string format, T parameter1)
        {
            if (!CanLogMessage(format))
            {
                return;
            }
            
            if (Tag is null)
            {
                LogPrivate(format, parameter1);
                return;
            }

            LogPrivate(AddTagToFormat(format), Tag, parameter1);
        }
        
        [MessageTemplateFormatMethod("format")]
        [Conditional(LoggerStaticData.ConditionalName)]
        public void Log<T1, T2>(string format, T1 parameter1, T2 parameter2)
        {
            if (!CanLogMessage(format))
            {
                return;
            }
            
            if (Tag is null)
            {
                LogPrivate(format, parameter1, parameter2);
                return;
            }

            LogPrivate(AddTagToFormat(format), Tag, parameter1, parameter2);
        }
        
        [MessageTemplateFormatMethod("format")]
        [Conditional(LoggerStaticData.ConditionalName)]
        public void Log<T1, T2, T3>(string format, T1 parameter1, T2 parameter2, T3 parameter3)
        {
            if (!CanLogMessage(format))
            {
                return;
            }
            
            if (Tag is null)
            {
                LogPrivate(format, parameter1, parameter2, parameter3);
                return;
            }

            LogPrivate(AddTagToFormat(format), Tag, parameter1, parameter2, parameter3);
        }
        
        [MessageTemplateFormatMethod("format")]
        [Conditional(LoggerStaticData.ConditionalName)]
        public void Log(string format, params object[] parameters)
        {
            if (!CanLogMessage(format))
            {
                return;
            }
            
            if (Tag is null)
            {
                RenderMessage(format, parameters);
                _logger.LogMessage(this, parameters);
                return;
            }

            var parametersWithTag = parameters.PrependValue(Tag);
            RenderMessage(AddTagToFormat(format), parametersWithTag);
            _logger.LogMessage(this, parametersWithTag);
        }
        
        private void LogPrivate<T>(string format, T parameter1)
        {
            var propertiesInlineArray = new PropertyInlineArray1();
            var parameters = propertiesInlineArray.AsSpan();
            parameters[0] = parameter1;
            RenderMessage(format, parameters);
            _logger.LogMessage(this, parameters);
        }
        
        private void LogPrivate<T1, T2>(string format, T1 parameter1, T2 parameter2)
        {
            var propertiesInlineArray = new PropertyInlineArray2();
            var parameters = propertiesInlineArray.AsSpan();
            parameters[0] = parameter1;
            parameters[1] = parameter2;
            RenderMessage(format, parameters);
            _logger.LogMessage(this, parameters);
        }
        
        private void LogPrivate<T1, T2, T3>(string format, T1 parameter1, T2 parameter2, T3 parameter3)
        {
            var propertiesInlineArray = new PropertyInlineArray3();
            var parameters = propertiesInlineArray.AsSpan();
            parameters[0] = parameter1;
            parameters[1] = parameter2;
            parameters[2] = parameter3;
            RenderMessage(format, parameters);
            _logger.LogMessage(this, parameters);
        }
        
        private void LogPrivate<T1, T2, T3, T4>(string format, T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4)
        {
            var propertiesInlineArray = new PropertyInlineArray4();
            var parameters = propertiesInlineArray.AsSpan();
            parameters[0] = parameter1;
            parameters[1] = parameter2;
            parameters[2] = parameter3;
            parameters[3] = parameter4;
            RenderMessage(format, parameters);
            _logger.LogMessage(this, parameters);
        }
        
        private void RenderMessage(string format, Span<object> parameters)
        {
            var messageFormat = _logger.ParseFormat(format);
            RenderedMessage = messageFormat.Render(this, parameters) ?? string.Empty;
        }
        
        private string AddTagToFormat(string format)
        {
            return _logger.LogTagProvider.AddTagToFormat(format);
        }

        private bool CanLogMessage(string format)
        {
            return _logger is not null && _logger.IsEnabled && !string.IsNullOrEmpty(format);
        }
    }
}