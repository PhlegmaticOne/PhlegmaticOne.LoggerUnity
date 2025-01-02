﻿using System;
using System.Diagnostics;
using Openmygame.Logger.Base;
using Openmygame.Logger.Configuration;
using Openmygame.Logger.Infrastructure.Attributes;
using Openmygame.Logger.Messages;

namespace Openmygame.Logger
{
    public static class LoggerExtensions
    {
        [Conditional(LoggerConfigurationData.ConditionalName), Conditional(LoggerConfigurationData.Editor)]
        public static void Debug(this ILogger logger, string messagePlain)
        {
            if (!logger.IsEnabled || string.IsNullOrEmpty(messagePlain))
            {
                return;
            }
            
            var message = logger.CreateMessage(LogLevel.Debug);
            message.Log(messagePlain);
        }
        
        [Conditional(LoggerConfigurationData.ConditionalName), Conditional(LoggerConfigurationData.Editor)]
        public static void TagDebug(this ILogger logger, string tag, string messagePlain)
        {
            if (!logger.IsEnabled || string.IsNullOrEmpty(messagePlain))
            {
                return;
            }
            
            var message = logger.CreateMessage(LogLevel.Debug, tag);
            message.Log(messagePlain);
        }
        
        [Conditional(LoggerConfigurationData.ConditionalName), Conditional(LoggerConfigurationData.Editor)]
        [MessageTemplateFormatMethod(LoggerConfigurationData.FormatParameterName)]
        public static void Debug(this ILogger logger, string format, params object[] parameters)
        {
            if (!logger.IsEnabled || string.IsNullOrEmpty(format))
            {
                return;
            }
            
            var message = logger.CreateMessage(LogLevel.Debug);
            message.Log(format, parameters);
        }
        
        [Conditional(LoggerConfigurationData.ConditionalName), Conditional(LoggerConfigurationData.Editor)]
        [MessageTemplateFormatMethod(LoggerConfigurationData.FormatParameterName)]
        public static void TagDebug(this ILogger logger, string tag, string format, params object[] parameters)
        {
            if (!logger.IsEnabled || string.IsNullOrEmpty(format))
            {
                return;
            }
            
            var message = logger.CreateMessage(LogLevel.Debug, tag);
            message.Log(format, parameters);
        }
        
        [Conditional(LoggerConfigurationData.ConditionalName), Conditional(LoggerConfigurationData.Editor)]
        public static void Warning(this ILogger logger, string messagePlain)
        {
            if (!logger.IsEnabled || string.IsNullOrEmpty(messagePlain))
            {
                return;
            }
            
            var message = logger.CreateMessage(LogLevel.Warning);
            message.Log(messagePlain);
        }
        
        [Conditional(LoggerConfigurationData.ConditionalName), Conditional(LoggerConfigurationData.Editor)]
        public static void TagWarning(this ILogger logger, string tag, string messagePlain)
        {
            if (!logger.IsEnabled || string.IsNullOrEmpty(messagePlain))
            {
                return;
            }
            
            var message = logger.CreateMessage(LogLevel.Warning, tag);
            message.Log(messagePlain);
        }
        
        [Conditional(LoggerConfigurationData.ConditionalName), Conditional(LoggerConfigurationData.Editor)]
        [MessageTemplateFormatMethod(LoggerConfigurationData.FormatParameterName)]
        public static void Warning(this ILogger logger, string format, params object[] parameters)
        {
            if (!logger.IsEnabled || string.IsNullOrEmpty(format))
            {
                return;
            }
            
            var message = logger.CreateMessage(LogLevel.Warning);
            message.Log(format, parameters);
        }
        
        [Conditional(LoggerConfigurationData.ConditionalName), Conditional(LoggerConfigurationData.Editor)]
        [MessageTemplateFormatMethod(LoggerConfigurationData.FormatParameterName)]
        public static void TagWarning(this ILogger logger, string tag, string format, params object[] parameters)
        {
            if (!logger.IsEnabled || string.IsNullOrEmpty(format))
            {
                return;
            }
            
            var message = logger.CreateMessage(LogLevel.Warning, tag);
            message.Log(format, parameters);
        }
        
        [Conditional(LoggerConfigurationData.ConditionalName), Conditional(LoggerConfigurationData.Editor)]
        public static void Error(this ILogger logger, string messagePlain)
        {
            if (!logger.IsEnabled || string.IsNullOrEmpty(messagePlain))
            {
                return;
            }
            
            var message = logger.CreateMessage(LogLevel.Error);
            message.Log(messagePlain);
        }
        
        [Conditional(LoggerConfigurationData.ConditionalName), Conditional(LoggerConfigurationData.Editor)]
        public static void TagError(this ILogger logger, string tag, string messagePlain)
        {
            if (!logger.IsEnabled || string.IsNullOrEmpty(messagePlain))
            {
                return;
            }
            
            var message = logger.CreateMessage(LogLevel.Error, tag);
            message.Log(messagePlain);
        }
        
        [Conditional(LoggerConfigurationData.ConditionalName), Conditional(LoggerConfigurationData.Editor)]
        [MessageTemplateFormatMethod(LoggerConfigurationData.FormatParameterName)]
        public static void Error(this ILogger logger, string format, params object[] parameters)
        {
            if (!logger.IsEnabled || string.IsNullOrEmpty(format))
            {
                return;
            }
            
            var message = logger.CreateMessage(LogLevel.Error);
            message.Log(format, parameters);
        }
        
        [Conditional(LoggerConfigurationData.ConditionalName), Conditional(LoggerConfigurationData.Editor)]
        [MessageTemplateFormatMethod(LoggerConfigurationData.FormatParameterName)]
        public static void TagError(this ILogger logger, string tag, string format, params object[] parameters)
        {
            if (!logger.IsEnabled || string.IsNullOrEmpty(format))
            {
                return;
            }
            
            var message = logger.CreateMessage(LogLevel.Error, tag);
            message.Log(format, parameters);
        }
        
        [Conditional(LoggerConfigurationData.ConditionalName), Conditional(LoggerConfigurationData.Editor)]
        public static void Fatal(this ILogger logger, string messagePlain)
        {
            if (!logger.IsEnabled || string.IsNullOrEmpty(messagePlain))
            {
                return;
            }
            
            var message = logger.CreateMessage(LogLevel.Fatal);
            message.Log(messagePlain);
        }
        
        [Conditional(LoggerConfigurationData.ConditionalName), Conditional(LoggerConfigurationData.Editor)]
        public static void TagFatal(this ILogger logger, string tag, string messagePlain)
        {
            if (!logger.IsEnabled || string.IsNullOrEmpty(messagePlain))
            {
                return;
            }
            
            var message = logger.CreateMessage(LogLevel.Fatal, tag);
            message.Log(messagePlain);
        }
        
        [Conditional(LoggerConfigurationData.ConditionalName), Conditional(LoggerConfigurationData.Editor)]
        [MessageTemplateFormatMethod(LoggerConfigurationData.FormatParameterName)]
        public static void Fatal(this ILogger logger, string format, params object[] parameters)
        {
            if (!logger.IsEnabled || string.IsNullOrEmpty(format))
            {
                return;
            }
            
            var message = logger.CreateMessage(LogLevel.Fatal);
            message.Log(format, parameters);
        }
        
        [Conditional(LoggerConfigurationData.ConditionalName), Conditional(LoggerConfigurationData.Editor)]
        [MessageTemplateFormatMethod(LoggerConfigurationData.FormatParameterName)]
        public static void TagFatal(this ILogger logger, string tag, string format, params object[] parameters)
        {
            if (!logger.IsEnabled || string.IsNullOrEmpty(format))
            {
                return;
            }
            
            var message = logger.CreateMessage(LogLevel.Fatal, tag);
            message.Log(format, parameters);
        }
        
        [Conditional(LoggerConfigurationData.ConditionalName), Conditional(LoggerConfigurationData.Editor)]
        public static void Exception(this ILogger logger, Exception exception)
        {
            if (!logger.IsEnabled || exception is null)
            {
                return;
            }
            
            var message = logger.CreateMessage(LogLevel.Fatal, exception: exception);
            message.Log(
                LoggerConfigurationData.ExceptionPlaceholderFormat, 
                LoggerConfigurationData.ExceptionPlaceholder);
        }
        
        [Conditional(LoggerConfigurationData.ConditionalName), Conditional(LoggerConfigurationData.Editor)]
        public static void Exception(this ILogger logger, Exception exception, string messagePlain)
        {
            if (!logger.IsEnabled || string.IsNullOrEmpty(messagePlain) || exception is null)
            {
                return;
            }

            var message = logger.CreateMessage(LogLevel.Fatal, exception: exception);
            message.Log(LoggerConfigurationData.MessageFormat, messagePlain);
        }
        
        [Conditional(LoggerConfigurationData.ConditionalName), Conditional(LoggerConfigurationData.Editor)]
        [MessageTemplateFormatMethod(LoggerConfigurationData.FormatParameterName)]
        public static void Exception(this ILogger logger, 
            Exception exception, string format, params object[] parameters)
        {
            if (!logger.IsEnabled || string.IsNullOrEmpty(format) || exception is null)
            {
                return;
            }

            var message = logger.CreateMessage(LogLevel.Fatal, exception: exception);
            message.Log(format, parameters);
        }

        [Conditional(LoggerConfigurationData.ConditionalName), Conditional(LoggerConfigurationData.Editor)]
        public static void TagException(this ILogger logger, string tag, Exception exception)
        {
            if (!logger.IsEnabled || exception is null)
            {
                return;
            }

            var message = logger.CreateMessage(LogLevel.Fatal, tag, exception);
            message.Log(
                LoggerConfigurationData.ExceptionPlaceholderFormat, 
                LoggerConfigurationData.ExceptionPlaceholder);
        }

        [Conditional(LoggerConfigurationData.ConditionalName), Conditional(LoggerConfigurationData.Editor)]
        public static void TagException(this ILogger logger, string tag, Exception exception, string messagePlain)
        {
            if (!logger.IsEnabled || string.IsNullOrEmpty(messagePlain) || exception is null)
            {
                return;
            }

            var message = logger.CreateMessage(LogLevel.Fatal, tag, exception);
            message.Log(LoggerConfigurationData.MessageFormat, messagePlain);
        }

        [Conditional(LoggerConfigurationData.ConditionalName), Conditional(LoggerConfigurationData.Editor)]
        [MessageTemplateFormatMethod(LoggerConfigurationData.FormatParameterName)]
        public static void TagException(this ILogger logger, 
            string tag, Exception exception, string format, params object[] parameters)
        {
            if (!logger.IsEnabled || string.IsNullOrEmpty(format) || exception is null)
            {
                return;
            }

            var message = logger.CreateMessage(LogLevel.Fatal, tag, exception);
            message.Log(format, parameters);
        }
    }
}