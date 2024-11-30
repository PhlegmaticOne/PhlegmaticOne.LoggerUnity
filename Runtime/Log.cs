using System;
using System.Diagnostics;
using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Configuration;
using OpenMyGame.LoggerUnity.Infrastructure.Attributes;
using OpenMyGame.LoggerUnity.Messages;

namespace OpenMyGame.LoggerUnity
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
        
        public static LogWithTag WithTag(string tag)
        {
            return new LogWithTag(tag);
        }
        
        [Conditional(LoggerConfigurationData.ConditionalName)]
        public static void Debug(string message)
        {
            Logger.Debug(message);
        }
        
        [Conditional(LoggerConfigurationData.ConditionalName)]
        [MessageTemplateFormatMethod(LoggerConfigurationData.FormatParameterName)]
        public static void Debug(string format, params object[] parameters)
        {
            Logger.Debug(format, parameters);
        }
        
        [Conditional(LoggerConfigurationData.ConditionalName)]
        public static void Warning(string message)
        {
            Logger.Warning(message);
        }

        [Conditional(LoggerConfigurationData.ConditionalName)]
        [MessageTemplateFormatMethod(LoggerConfigurationData.FormatParameterName)]
        public static void Warning(string format, params object[] parameters)
        {
            Logger.Warning(format, parameters);
        }
        
        [Conditional(LoggerConfigurationData.ConditionalName)]
        public static void Error(string message)
        {
            Logger.Error(message);
        }

        [Conditional(LoggerConfigurationData.ConditionalName)]
        [MessageTemplateFormatMethod(LoggerConfigurationData.FormatParameterName)]
        public static void Error(string format, params object[] parameters)
        {
            Logger.Error(format, parameters);
        }
        
        [Conditional(LoggerConfigurationData.ConditionalName)]
        public static void Fatal(string message)
        {
            Logger.Fatal(message);
        }

        [Conditional(LoggerConfigurationData.ConditionalName)]
        [MessageTemplateFormatMethod(LoggerConfigurationData.FormatParameterName)]
        public static void Fatal(string format, params object[] parameters)
        {
            Logger.Fatal(format, parameters);
        }
        
        [Conditional(LoggerConfigurationData.ConditionalName)]
        public static void Exception(Exception exception)
        {
            Logger.Exception(exception);
        }

        public static LogMessage DebugMessage(string tag = null, Exception exception = null)
        {
            return Logger.DebugMessage(tag, exception);
        }

        public static LogMessage WarningMessage(string tag = null, Exception exception = null)
        {
            return Logger.WarningMessage(tag, exception);
        }

        public static LogMessage ErrorMessage(string tag = null, Exception exception = null)
        {
            return Logger.ErrorMessage(tag, exception);
        }

        public static LogMessage FatalMessage(string tag = null, Exception exception = null)
        {
            return Logger.FatalMessage(tag, exception);
        }
    }
}