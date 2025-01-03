﻿using System;
using System.Diagnostics;
using Openmygame.Logger.Configuration;
using Openmygame.Logger.Infrastructure.Attributes;
using Openmygame.Logger.Infrastructure.InlineArrays;
using Openmygame.Logger.Messages;
using Openmygame.Logger.Messages.Exceptions;
using ILogger = Openmygame.Logger.Base.ILogger;

namespace Openmygame.Logger
{
    public static class LoggerExtensions
    {
        public static ILogger Tag(this ILogger logger, string tag, string tagFormat = null)
        {
            return Log.Tag(tag, tagFormat, logger);
        }

        public static ILogger Subsystem(this ILogger logger, string subsystem, string subsystemFormat = null)
        {
            return Log.Subsystem(subsystem, subsystemFormat, logger);
        }
        
        [Conditional(LoggerConfigurationData.EnableConditionalName), Conditional(LoggerConfigurationData.Editor)]
        public static void Debug(this ILogger logger, string messagePlain)
        {
            if (logger is null || !logger.IsEnabled || string.IsNullOrEmpty(messagePlain))
            {
                return;
            }
            
            var message = new LogMessage(LogLevel.Debug, LoggerConfigurationData.MessageFormat);
            var array = new PropertyInlineArray();
            var parameters = array.AsSpan();
            parameters[0] = messagePlain;
            logger.LogMessage(message, parameters);
        }
        
        [Conditional(LoggerConfigurationData.EnableConditionalName), Conditional(LoggerConfigurationData.Editor)]
        [MessageTemplateFormatMethod(LoggerConfigurationData.FormatParameterName)]
        public static void Debug(this ILogger logger, string format, params object[] parameters)
        {
            if (logger is null || !logger.IsEnabled || string.IsNullOrEmpty(format))
            {
                return;
            }
            
            var message = new LogMessage(LogLevel.Debug, format);
            logger.LogMessage(message, parameters);
        }
        
        [Conditional(LoggerConfigurationData.EnableConditionalName), Conditional(LoggerConfigurationData.Editor)]
        public static void Warning(this ILogger logger, string messagePlain)
        {
            if (logger is null || !logger.IsEnabled || string.IsNullOrEmpty(messagePlain))
            {
                return;
            }

            var message = new LogMessage(LogLevel.Warning, LoggerConfigurationData.MessageFormat);
            var array = new PropertyInlineArray();
            var parameters = array.AsSpan();
            parameters[0] = messagePlain;
            logger.LogMessage(message, parameters);
        }
        
        [Conditional(LoggerConfigurationData.EnableConditionalName), Conditional(LoggerConfigurationData.Editor)]
        [MessageTemplateFormatMethod(LoggerConfigurationData.FormatParameterName)]
        public static void Warning(this ILogger logger, string format, params object[] parameters)
        {
            if (logger is null || !logger.IsEnabled || string.IsNullOrEmpty(format))
            {
                return;
            }
            
            var message = new LogMessage(LogLevel.Warning, format);
            logger.LogMessage(message, parameters);
        }
        
        [Conditional(LoggerConfigurationData.EnableConditionalName), Conditional(LoggerConfigurationData.Editor)]
        public static void Error(this ILogger logger, string messagePlain)
        {
            if (logger is null || !logger.IsEnabled || string.IsNullOrEmpty(messagePlain))
            {
                return;
            }
            
            var message = new LogMessage(LogLevel.Error, LoggerConfigurationData.MessageFormat);
            var array = new PropertyInlineArray();
            var parameters = array.AsSpan();
            parameters[0] = messagePlain;
            logger.LogMessage(message, parameters);
        }
        
        [Conditional(LoggerConfigurationData.EnableConditionalName), Conditional(LoggerConfigurationData.Editor)]
        [MessageTemplateFormatMethod(LoggerConfigurationData.FormatParameterName)]
        public static void Error(this ILogger logger, string format, params object[] parameters)
        {
            if (logger is null || !logger.IsEnabled || string.IsNullOrEmpty(format))
            {
                return;
            }
            
            var message = new LogMessage(LogLevel.Error, format);
            logger.LogMessage(message, parameters);
        }
        
        [Conditional(LoggerConfigurationData.EnableConditionalName), Conditional(LoggerConfigurationData.Editor)]
        public static void Fatal(this ILogger logger, string messagePlain)
        {
            Fatal(logger, null, messagePlain);
        }
        
        [Conditional(LoggerConfigurationData.EnableConditionalName), Conditional(LoggerConfigurationData.Editor)]
        public static void Fatal(this ILogger logger, Exception exception, string messagePlain)
        {
            if (logger is null || !logger.IsEnabled || string.IsNullOrEmpty(messagePlain))
            {
                return;
            }
            
            var message = new LogMessage(LogLevel.Fatal, LoggerConfigurationData.MessageFormat, exception);
            var array = new PropertyInlineArray();
            var parameters = array.AsSpan();
            parameters[0] = messagePlain;
            logger.LogMessage(message, parameters);
        }
        
        [Conditional(LoggerConfigurationData.EnableConditionalName), Conditional(LoggerConfigurationData.Editor)]
        [MessageTemplateFormatMethod(LoggerConfigurationData.FormatParameterName)]
        public static void Fatal(this ILogger logger, string format, params object[] parameters)
        {
            Fatal(logger, null, format, parameters);
        }
        
        [Conditional(LoggerConfigurationData.EnableConditionalName), Conditional(LoggerConfigurationData.Editor)]
        [MessageTemplateFormatMethod(LoggerConfigurationData.FormatParameterName)]
        public static void Fatal(this ILogger logger, Exception exception, string format, params object[] parameters)
        {
            if (logger is null || !logger.IsEnabled || string.IsNullOrEmpty(format))
            {
                return;
            }
            
            var message = new LogMessage(LogLevel.Fatal, format, exception);
            logger.LogMessage(message, parameters);
        }
        
        [Conditional(LoggerConfigurationData.EnableConditionalName), 
         Conditional(LoggerConfigurationData.Editor),
         Conditional(LoggerConfigurationData.ExceptionConditionalName)]
        public static void Exception(this ILogger logger, Exception exception)
        {
            if (logger is null || !logger.IsEnabled || exception is null)
            {
                return;
            }
            
            var message = new LogMessage(LogLevel.Fatal, LoggerConfigurationData.ExceptionPlaceholderFormat, exception);
            var array = new PropertyInlineArray();
            var parameters = array.AsSpan();
            parameters[0] = new ExceptionPlaceholder(exception.Message);
            logger.LogMessage(message, parameters);
        }
        
        [Conditional(LoggerConfigurationData.EnableConditionalName), 
         Conditional(LoggerConfigurationData.Editor),
         Conditional(LoggerConfigurationData.ExceptionConditionalName)]
        public static void Exception(this ILogger logger, Exception exception, string messagePlain)
        {
            if (logger is null || !logger.IsEnabled || string.IsNullOrEmpty(messagePlain) || exception is null)
            {
                return;
            }

            var message = new LogMessage(LogLevel.Fatal, LoggerConfigurationData.MessageFormat, exception);
            var array = new PropertyInlineArray();
            var parameters = array.AsSpan();
            parameters[0] = messagePlain;
            logger.LogMessage(message, parameters);
        }
        
        [Conditional(LoggerConfigurationData.EnableConditionalName), 
         Conditional(LoggerConfigurationData.Editor),
         Conditional(LoggerConfigurationData.ExceptionConditionalName)]
        [MessageTemplateFormatMethod(LoggerConfigurationData.FormatParameterName)]
        public static void Exception(this ILogger logger, 
            Exception exception, string format, params object[] parameters)
        {
            if (logger is null || !logger.IsEnabled || string.IsNullOrEmpty(format) || exception is null)
            {
                return;
            }

            var message = new LogMessage(LogLevel.Fatal, format, exception);
            logger.LogMessage(message, parameters);
        }
    }
}