﻿using System;
using System.Diagnostics;
using Openmygame.Logger.Configuration;
using Openmygame.Logger.Infrastructure.Attributes;
using Openmygame.Logger.Messages;
using Openmygame.Logger.Messages.Tagging;
using ILogger = Openmygame.Logger.Base.ILogger;

namespace Openmygame.Logger
{
    public class Log : ILogger
    {
        public static ILogger Logger { get; set; } = new LogNull();
        
        public bool IsEnabled
        {
            get => Logger.IsEnabled; 
            set => Logger.IsEnabled = value;
        }

        public void LogMessage(LogMessage message, Span<object> parameters)
        {
            Logger.LogMessage(message, parameters);
        }
        
        public static ILogger Tag(string tag, string tagFormat = null, ILogger logger = null)
        {
            var format = string.IsNullOrEmpty(tagFormat) ? LogTagFormatsProvider.Tag() : tagFormat;
            return TagLogger(tag, format, false, logger);
        }
        
        public static ILogger Subsystem(string subsystem, string subsystemFormat = null, ILogger logger = null)
        {
            var format = string.IsNullOrEmpty(subsystemFormat) ? LogTagFormatsProvider.Subsystem() : subsystemFormat;
            return TagLogger(subsystem, format, true, logger);
        }

        public static ILogger TagSubsystem(string tag, string subsystem,
            string tagFormat = null, string subsystemFormat = null, ILogger logger = null)
        {
            return Subsystem(subsystem, subsystemFormat, Tag(tag, tagFormat, logger));
        }
        
        [Conditional(LoggerConfigurationData.EnableConditionalName), Conditional(LoggerConfigurationData.Editor)]
        public static void Debug(string messagePlain)
        {
            Logger.Debug(messagePlain);
        }
        
        [Conditional(LoggerConfigurationData.EnableConditionalName), Conditional(LoggerConfigurationData.Editor)]
        public static void TagDebug(string tag, string messagePlain)
        {
            Tag(tag).Debug(messagePlain);
        }
        
        [Conditional(LoggerConfigurationData.EnableConditionalName), Conditional(LoggerConfigurationData.Editor)]
        [MessageTemplateFormatMethod(LoggerConfigurationData.FormatParameterName)]
        public static void Debug(string format, params object[] parameters)
        {
            Logger.Debug(format, parameters);
        }
        
        [Conditional(LoggerConfigurationData.EnableConditionalName), Conditional(LoggerConfigurationData.Editor)]
        [MessageTemplateFormatMethod(LoggerConfigurationData.FormatParameterName)]
        public static void TagDebug(string tag, string format, params object[] parameters)
        {
            Tag(tag).Debug(format, parameters);
        }
        
        [Conditional(LoggerConfigurationData.EnableConditionalName), Conditional(LoggerConfigurationData.Editor)]
        public static void Warning(string messagePlain)
        {
            Logger.Warning(messagePlain);
        }
        
        [Conditional(LoggerConfigurationData.EnableConditionalName), Conditional(LoggerConfigurationData.Editor)]
        public static void TagWarning(string tag, string messagePlain)
        {
            Tag(tag).Warning(messagePlain);
        }

        [Conditional(LoggerConfigurationData.EnableConditionalName), Conditional(LoggerConfigurationData.Editor)]
        [MessageTemplateFormatMethod(LoggerConfigurationData.FormatParameterName)]
        public static void Warning(string format, params object[] parameters)
        {
            Logger.Warning(format, parameters);
        }
        
        [Conditional(LoggerConfigurationData.EnableConditionalName), Conditional(LoggerConfigurationData.Editor)]
        [MessageTemplateFormatMethod(LoggerConfigurationData.FormatParameterName)]
        public static void TagWarning(string tag, string format, params object[] parameters)
        {
            Tag(tag).Warning(format, parameters);
        }
        
        [Conditional(LoggerConfigurationData.EnableConditionalName), Conditional(LoggerConfigurationData.Editor)]
        public static void Error(string messagePlain)
        {
            Logger.Error(messagePlain);
        }
        
        [Conditional(LoggerConfigurationData.EnableConditionalName), Conditional(LoggerConfigurationData.Editor)]
        public static void TagError(string tag, string messagePlain)
        {
            Tag(tag).Error(messagePlain);
        }

        [Conditional(LoggerConfigurationData.EnableConditionalName), Conditional(LoggerConfigurationData.Editor)]
        [MessageTemplateFormatMethod(LoggerConfigurationData.FormatParameterName)]
        public static void Error(string format, params object[] parameters)
        {
            Logger.Error(format, parameters);
        }
        
        [Conditional(LoggerConfigurationData.EnableConditionalName), Conditional(LoggerConfigurationData.Editor)]
        [MessageTemplateFormatMethod(LoggerConfigurationData.FormatParameterName)]
        public static void TagError(string tag, string format, params object[] parameters)
        {
            Tag(tag).Error(format, parameters);
        }
        
        [Conditional(LoggerConfigurationData.EnableConditionalName), 
         Conditional(LoggerConfigurationData.Editor),
         Conditional(LoggerConfigurationData.ExceptionConditionalName)]
        public static void Fatal(string messagePlain)
        {
            Logger.Fatal(messagePlain);
        }
        
        [Conditional(LoggerConfigurationData.EnableConditionalName), 
         Conditional(LoggerConfigurationData.Editor),
         Conditional(LoggerConfigurationData.ExceptionConditionalName)]
        public static void TagFatal(string tag, string messagePlain)
        {
            Tag(tag).Fatal(messagePlain);
        }

        [Conditional(LoggerConfigurationData.EnableConditionalName), 
         Conditional(LoggerConfigurationData.Editor),
         Conditional(LoggerConfigurationData.ExceptionConditionalName)]
        [MessageTemplateFormatMethod(LoggerConfigurationData.FormatParameterName)]
        public static void Fatal(string format, params object[] parameters)
        {
            Logger.Fatal(format, parameters);
        }
        
        [Conditional(LoggerConfigurationData.EnableConditionalName), 
         Conditional(LoggerConfigurationData.Editor),
         Conditional(LoggerConfigurationData.ExceptionConditionalName)]
        [MessageTemplateFormatMethod(LoggerConfigurationData.FormatParameterName)]
        public static void TagFatal(string tag, string format, params object[] parameters)
        {
            Tag(tag).Fatal(format, parameters);
        }
        
        [Conditional(LoggerConfigurationData.EnableConditionalName), 
         Conditional(LoggerConfigurationData.Editor),
         Conditional(LoggerConfigurationData.ExceptionConditionalName)]
        public static void Exception(Exception exception)
        {
            Logger.Exception(exception);
        }
        
        [Conditional(LoggerConfigurationData.EnableConditionalName), 
         Conditional(LoggerConfigurationData.Editor),
         Conditional(LoggerConfigurationData.ExceptionConditionalName)]
        public static void Exception(Exception exception, string messagePlain)
        {
            Logger.Exception(exception, messagePlain);
        }
        
        [Conditional(LoggerConfigurationData.EnableConditionalName), 
         Conditional(LoggerConfigurationData.Editor),
         Conditional(LoggerConfigurationData.ExceptionConditionalName)]
        [MessageTemplateFormatMethod(LoggerConfigurationData.FormatParameterName)]
        public static void Exception(Exception exception, string format, params object[] parameters)
        {
            Logger.Exception(exception, format, parameters);
        }

        [Conditional(LoggerConfigurationData.EnableConditionalName), 
         Conditional(LoggerConfigurationData.Editor),
         Conditional(LoggerConfigurationData.ExceptionConditionalName)]
        public static void TagException(string tag, Exception exception)
        {
            Tag(tag).Exception(exception);
        }

        [Conditional(LoggerConfigurationData.EnableConditionalName), 
         Conditional(LoggerConfigurationData.Editor),
         Conditional(LoggerConfigurationData.ExceptionConditionalName)]
        public static void TagException(string tag, Exception exception, string messagePlain)
        {
            Tag(tag).Exception(exception, messagePlain);
        }

        [Conditional(LoggerConfigurationData.EnableConditionalName), 
         Conditional(LoggerConfigurationData.Editor),
         Conditional(LoggerConfigurationData.ExceptionConditionalName)]
        [MessageTemplateFormatMethod(LoggerConfigurationData.FormatParameterName)]
        public static void TagException(string tag, Exception exception, string format, params object[] parameters)
        {
            Tag(tag).Exception(exception, format, parameters);
        }

        private static LogTag TagLogger(string tag, string format, bool isSubsystem, ILogger logger)
        {
            var internalLogger = logger ?? Logger;
            var internalTag = Messages.Tagging.Tag.Create(tag, format, isSubsystem);
            return new LogTag(internalTag, internalLogger);
        }
    }
}