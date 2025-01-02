using System;
using System.Diagnostics;
using Openmygame.Logger.Base;
using Openmygame.Logger.Configuration;
using Openmygame.Logger.Infrastructure.Attributes;
using Openmygame.Logger.Messages;

namespace Openmygame.Logger
{
    public class Log : ILogger
    {
        public static ILogger Logger { get; set; } = new NullLogger();
        
        public bool IsEnabled
        {
            get => Logger.IsEnabled; 
            set => Logger.IsEnabled = value;
        }
                
        public LogMessage CreateMessage(LogLevel logLevel, string tag = null, Exception exception = null)
        {
            return Logger.CreateMessage(logLevel, tag, exception);
        }

        public void LogMessage(LogMessage message, Span<object> parameters)
        {
            Logger.LogMessage(message, parameters);
        }
        
        public static LogWithTag TagLogger(string tag)
        {
            return new LogWithTag(tag, Logger);
        }
        
        [Conditional(LoggerConfigurationData.ConditionalName), Conditional(LoggerConfigurationData.Editor)]
        public static void Debug(string messagePlain)
        {
            Logger.Debug(messagePlain);
        }
        
        [Conditional(LoggerConfigurationData.ConditionalName), Conditional(LoggerConfigurationData.Editor)]
        public static void TagDebug(string tag, string messagePlain)
        {
            Logger.TagDebug(tag, messagePlain);
        }
        
        [Conditional(LoggerConfigurationData.ConditionalName), Conditional(LoggerConfigurationData.Editor)]
        [MessageTemplateFormatMethod(LoggerConfigurationData.FormatParameterName)]
        public static void Debug(string format, params object[] parameters)
        {
            Logger.Debug(format, parameters);
        }
        
        [Conditional(LoggerConfigurationData.ConditionalName), Conditional(LoggerConfigurationData.Editor)]
        [MessageTemplateFormatMethod(LoggerConfigurationData.FormatParameterName)]
        public static void TagDebug(string tag, string format, params object[] parameters)
        {
            Logger.TagDebug(tag, format, parameters);
        }
        
        [Conditional(LoggerConfigurationData.ConditionalName), Conditional(LoggerConfigurationData.Editor)]
        public static void Warning(string messagePlain)
        {
            Logger.Warning(messagePlain);
        }
        
        [Conditional(LoggerConfigurationData.ConditionalName), Conditional(LoggerConfigurationData.Editor)]
        public static void TagWarning(string tag, string messagePlain)
        {
            Logger.TagWarning(tag, messagePlain);
        }

        [Conditional(LoggerConfigurationData.ConditionalName), Conditional(LoggerConfigurationData.Editor)]
        [MessageTemplateFormatMethod(LoggerConfigurationData.FormatParameterName)]
        public static void Warning(string format, params object[] parameters)
        {
            Logger.Warning(format, parameters);
        }
        
        [Conditional(LoggerConfigurationData.ConditionalName), Conditional(LoggerConfigurationData.Editor)]
        [MessageTemplateFormatMethod(LoggerConfigurationData.FormatParameterName)]
        public static void TagWarning(string tag, string format, params object[] parameters)
        {
            Logger.TagWarning(tag, format, parameters);
        }
        
        [Conditional(LoggerConfigurationData.ConditionalName), Conditional(LoggerConfigurationData.Editor)]
        public static void Error(string messagePlain)
        {
            Logger.Error(messagePlain);
        }
        
        [Conditional(LoggerConfigurationData.ConditionalName), Conditional(LoggerConfigurationData.Editor)]
        public static void TagError(string tag, string messagePlain)
        {
            Logger.TagError(tag, messagePlain);
        }

        [Conditional(LoggerConfigurationData.ConditionalName), Conditional(LoggerConfigurationData.Editor)]
        [MessageTemplateFormatMethod(LoggerConfigurationData.FormatParameterName)]
        public static void Error(string format, params object[] parameters)
        {
            Logger.Error(format, parameters);
        }
        
        [Conditional(LoggerConfigurationData.ConditionalName), Conditional(LoggerConfigurationData.Editor)]
        [MessageTemplateFormatMethod(LoggerConfigurationData.FormatParameterName)]
        public static void TagError(string tag, string format, params object[] parameters)
        {
            Logger.TagError(tag, format, parameters);
        }
        
        [Conditional(LoggerConfigurationData.ConditionalName), Conditional(LoggerConfigurationData.Editor)]
        public static void Fatal(string messagePlain)
        {
            Logger.Fatal(messagePlain);
        }
        
        [Conditional(LoggerConfigurationData.ConditionalName), Conditional(LoggerConfigurationData.Editor)]
        public static void TagFatal(string tag, string messagePlain)
        {
            Logger.TagFatal(tag, messagePlain);
        }

        [Conditional(LoggerConfigurationData.ConditionalName), Conditional(LoggerConfigurationData.Editor)]
        [MessageTemplateFormatMethod(LoggerConfigurationData.FormatParameterName)]
        public static void Fatal(string format, params object[] parameters)
        {
            Logger.Fatal(format, parameters);
        }
        
        [Conditional(LoggerConfigurationData.ConditionalName), Conditional(LoggerConfigurationData.Editor)]
        [MessageTemplateFormatMethod(LoggerConfigurationData.FormatParameterName)]
        public static void TagFatal(string tag, string format, params object[] parameters)
        {
            Logger.TagFatal(tag, format, parameters);
        }
        
        [Conditional(LoggerConfigurationData.ConditionalName), Conditional(LoggerConfigurationData.Editor)]
        public static void Exception(Exception exception)
        {
            Logger.Exception(exception);
        }
        
        [Conditional(LoggerConfigurationData.ConditionalName), Conditional(LoggerConfigurationData.Editor)]
        public static void Exception(Exception exception, string messagePlain)
        {
            Logger.Exception(exception, messagePlain);
        }
        
        [Conditional(LoggerConfigurationData.ConditionalName), Conditional(LoggerConfigurationData.Editor)]
        [MessageTemplateFormatMethod(LoggerConfigurationData.FormatParameterName)]
        public static void Exception(Exception exception, string format, params object[] parameters)
        {
            Logger.Exception(exception, format, parameters);
        }

        [Conditional(LoggerConfigurationData.ConditionalName), Conditional(LoggerConfigurationData.Editor)]
        public static void TagException(string tag, Exception exception)
        {
            Logger.TagException(tag, exception);
        }

        [Conditional(LoggerConfigurationData.ConditionalName), Conditional(LoggerConfigurationData.Editor)]
        public static void TagException(string tag, Exception exception, string messagePlain)
        {
            Logger.TagException(tag, exception, messagePlain);
        }

        [Conditional(LoggerConfigurationData.ConditionalName), Conditional(LoggerConfigurationData.Editor)]
        [MessageTemplateFormatMethod(LoggerConfigurationData.FormatParameterName)]
        public static void TagException(string tag, Exception exception, string format, params object[] parameters)
        {
            Logger.TagException(tag, exception, format, parameters);
        }
    }
}