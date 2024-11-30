using System;
using System.Diagnostics;
using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Configuration;
using OpenMyGame.LoggerUnity.Infrastructure.Attributes;
using OpenMyGame.LoggerUnity.Messages;

namespace OpenMyGame.LoggerUnity
{
    public static class LoggerExtensions
    {
        [Conditional(LoggerConfigurationData.ConditionalName)]
        public static void Debug(this ILogger logger, string messagePlain)
        {
            logger.DebugMessage().Log(messagePlain);
        }
        
        [Conditional(LoggerConfigurationData.ConditionalName)]
        [MessageTemplateFormatMethod(LoggerConfigurationData.FormatParameterName)]
        public static void Debug(this ILogger logger, string format, params object[] parameters)
        {
            logger.DebugMessage().Log(format, parameters);
        }
        
        [Conditional(LoggerConfigurationData.ConditionalName)]
        public static void Warning(this ILogger logger, string messagePlain)
        {
            logger.WarningMessage().Log(messagePlain);
        }
        
        [Conditional(LoggerConfigurationData.ConditionalName)]
        [MessageTemplateFormatMethod(LoggerConfigurationData.FormatParameterName)]
        public static void Warning(this ILogger logger, string format, params object[] parameters)
        {
            logger.WarningMessage().Log(format, parameters);
        }
        
        [Conditional(LoggerConfigurationData.ConditionalName)]
        public static void Error(this ILogger logger, string messagePlain)
        {
            logger.ErrorMessage().Log(messagePlain);
        }
        
        [Conditional(LoggerConfigurationData.ConditionalName)]
        [MessageTemplateFormatMethod(LoggerConfigurationData.FormatParameterName)]
        public static void Error(this ILogger logger, string format, params object[] parameters)
        {
            logger.ErrorMessage().Log(format, parameters);
        }
        
        [Conditional(LoggerConfigurationData.ConditionalName)]
        public static void Fatal(this ILogger logger, string messagePlain)
        {
            logger.FatalMessage().Log(messagePlain);
        }
        
        [Conditional(LoggerConfigurationData.ConditionalName)]
        [MessageTemplateFormatMethod(LoggerConfigurationData.FormatParameterName)]
        public static void Fatal(this ILogger logger, string format, params object[] parameters)
        {
            logger.FatalMessage().Log(format, parameters);
        }
        
        [Conditional(LoggerConfigurationData.ConditionalName)]
        public static void Exception(this ILogger logger, Exception exception)
        {
            if (!logger.IsEnabled || exception is null)
            {
                return;
            }

            logger.FatalMessage(exception: exception).Log(
                LoggerConfigurationData.ExceptionPlaceholderFormat, 
                LoggerConfigurationData.ExceptionPlaceholder);
        }

        public static LogMessage DebugMessage(this ILogger logger, Exception exception = null) => 
            logger.CreateMessage(LogLevel.Debug, null, exception);

        public static LogMessage DebugMessage(this ILogger logger, string tag) => 
            logger.CreateMessage(LogLevel.Debug, tag);
        public static LogMessage DebugMessage(this ILogger logger, string tag, Exception exception) => 
            logger.CreateMessage(LogLevel.Debug, tag, exception);

        public static LogMessage WarningMessage(this ILogger logger, Exception exception = null) => 
            logger.CreateMessage(LogLevel.Warning, null, exception);

        public static LogMessage WarningMessage(this ILogger logger, string tag) => 
            logger.CreateMessage(LogLevel.Warning, tag);
        public static LogMessage WarningMessage(this ILogger logger, string tag, Exception exception) => 
            logger.CreateMessage(LogLevel.Warning, tag, exception);

        public static LogMessage ErrorMessage(this ILogger logger, Exception exception = null) => 
            logger.CreateMessage(LogLevel.Error, null, exception);

        public static LogMessage ErrorMessage(this ILogger logger, string tag) => 
            logger.CreateMessage(LogLevel.Error, tag);
        public static LogMessage ErrorMessage(this ILogger logger, string tag, Exception exception) => 
            logger.CreateMessage(LogLevel.Error, tag, exception);

        public static LogMessage FatalMessage(this ILogger logger, Exception exception = null) => 
            logger.CreateMessage(LogLevel.Fatal, null, exception);

        public static LogMessage FatalMessage(this ILogger logger, string tag) => 
            logger.CreateMessage(LogLevel.Fatal, tag);
        public static LogMessage FatalMessage(this ILogger logger, string tag, Exception exception) => 
            logger.CreateMessage(LogLevel.Fatal, tag, exception);
    }
}