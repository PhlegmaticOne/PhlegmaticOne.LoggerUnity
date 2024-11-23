using System;
using System.Buffers;
using System.Diagnostics;
using OpenMyGame.LoggerUnity.Configuration;
using OpenMyGame.LoggerUnity.Extensions;
using OpenMyGame.LoggerUnity.Infrastructure.Attributes;
using OpenMyGame.LoggerUnity.Infrastructure.InlineArrays;
using OpenMyGame.LoggerUnity.Messages.Tagging;

namespace OpenMyGame.LoggerUnity.Messages
{
    public partial struct LogMessage
    {
        private const string FormatParameterName = "format";
        
        [Conditional(LoggerConfigurationData.ConditionalName)]
        public void Log(string format)
        {
            if (!CanLogMessage(format))
            {
                return;
            }
            
            if (!Tag.HasValue())
            {
                LogPrivate(format, Span<object>.Empty);
                return;
            }

            LogPrivate(AddTagToFormat(format), Tag);
        }
        
        [MessageTemplateFormatMethod(FormatParameterName)]
        [Conditional(LoggerConfigurationData.ConditionalName)]
        public void Log<T>(string format, T parameter1)
        {
            if (!CanLogMessage(format))
            {
                return;
            }
            
            if (!Tag.HasValue())
            {
                LogPrivate(format, parameter1);
                return;
            }

            LogPrivate(AddTagToFormat(format), Tag, parameter1);
        }
        
        [MessageTemplateFormatMethod(FormatParameterName)]
        [Conditional(LoggerConfigurationData.ConditionalName)]
        public void Log<T1, T2>(string format, T1 parameter1, T2 parameter2)
        {
            if (!CanLogMessage(format))
            {
                return;
            }
            
            if (!Tag.HasValue())
            {
                LogPrivate(format, parameter1, parameter2);
                return;
            }

            LogPrivate(AddTagToFormat(format), Tag, parameter1, parameter2);
        }
        
        [MessageTemplateFormatMethod(FormatParameterName)]
        [Conditional(LoggerConfigurationData.ConditionalName)]
        public void Log<T1, T2, T3>(string format, T1 parameter1, T2 parameter2, T3 parameter3)
        {
            if (!CanLogMessage(format))
            {
                return;
            }
            
            if (!Tag.HasValue())
            {
                LogPrivate(format, parameter1, parameter2, parameter3);
                return;
            }

            LogPrivate(AddTagToFormat(format), Tag, parameter1, parameter2, parameter3);
        }
        
        [MessageTemplateFormatMethod(FormatParameterName)]
        [Conditional(LoggerConfigurationData.ConditionalName)]
        public void Log(string format, params object[] parameters)
        {
            if (!CanLogMessage(format))
            {
                return;
            }
            
            if (!Tag.HasValue())
            {
                LogPrivate(format, parameters.AsSpan());
                return;
            }
            
            var parametersAppend = parameters.PrependValue(Tag); 
            LogPrivate(AddTagToFormat(format), parametersAppend.AsSpan());
            ArrayPool<object>.Shared.Return(parametersAppend, true);
        }
        
        private void LogPrivate<T>(string format, T parameter1)
        {
            Format = format;
            var propertiesInlineArray = new PropertyInlineArray1();
            var parameters = propertiesInlineArray.AsSpan();
            parameters[0] = parameter1;
            LoggerUnity.Log.Logger.LogMessage(this, parameters);
        }
        
        private void LogPrivate<T1, T2>(string format, T1 parameter1, T2 parameter2)
        {
            Format = format;
            var propertiesInlineArray = new PropertyInlineArray2();
            var parameters = propertiesInlineArray.AsSpan();
            parameters[0] = parameter1;
            parameters[1] = parameter2;
            LoggerUnity.Log.Logger.LogMessage(this, parameters);
        }
        
        private void LogPrivate<T1, T2, T3>(string format, T1 parameter1, T2 parameter2, T3 parameter3)
        {
            Format = format;
            var propertiesInlineArray = new PropertyInlineArray3();
            var parameters = propertiesInlineArray.AsSpan();
            parameters[0] = parameter1;
            parameters[1] = parameter2;
            parameters[2] = parameter3;
            LoggerUnity.Log.Logger.LogMessage(this, parameters);
        }
        
        private void LogPrivate<T1, T2, T3, T4>(string format, T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4)
        {
            Format = format;
            var propertiesInlineArray = new PropertyInlineArray4();
            var parameters = propertiesInlineArray.AsSpan();
            parameters[0] = parameter1;
            parameters[1] = parameter2;
            parameters[2] = parameter3;
            parameters[3] = parameter4;
            LoggerUnity.Log.Logger.LogMessage(this, parameters);
        }

        private void LogPrivate(string format, Span<object> parameters)
        {
            Format = format;
            LoggerUnity.Log.Logger.LogMessage(this, parameters);
        }

        private static bool CanLogMessage(string format)
        {
            return LoggerUnity.Log.Logger.IsEnabled && !string.IsNullOrEmpty(format);
        }

        private static string AddTagToFormat(string format)
        {
            return LogTag.Format.AddTagToFormat(format);
        }
    }
}