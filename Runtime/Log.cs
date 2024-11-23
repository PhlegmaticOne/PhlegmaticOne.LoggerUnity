using System;
using System.Diagnostics;
using OpenMyGame.LoggerUnity.Attributes;
using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Messages;

namespace OpenMyGame.LoggerUnity
{
    public static class Log
    {
        private const string FormatParameterName = "format";
        
        private static ILogger LoggerPrivate = new NullLogger();

        public static ILogger Logger
        {
            get => LoggerPrivate;
            set
            {
                LoggerPrivate?.Dispose();
                LoggerPrivate = value;
            }
        }

        public static void SetDestinationEnabled(string destinationName, bool isEnabled)
        {
            Logger.SetDestinationEnabled(destinationName, isEnabled);
        }

        [Conditional(LoggerStaticData.ConditionalName)]
        public static void Exception(Exception exception)
        {
            if (!Logger.IsEnabled || exception is null)
            {
                return;
            }

            FatalMessage(exception: exception).Log(
                LoggerStaticData.ExceptionPlaceholderFormat, LoggerStaticData.ExceptionPlaceholder);
        }

        public static LogWithTag WithTag(string tag)
        {
            return new LogWithTag(tag);
        }
        
        [Conditional(LoggerStaticData.ConditionalName)]
        public static void Debug(string message)
        {
            DebugMessage().Log(message);
        }
        
        [MessageTemplateFormatMethod(FormatParameterName)]
        [Conditional(LoggerStaticData.ConditionalName)]
        public static void Debug<T>(string format, T parameter1)
        {
            DebugMessage().Log(format, parameter1);
        }
        
        [MessageTemplateFormatMethod(FormatParameterName)]
        [Conditional(LoggerStaticData.ConditionalName)]
        public static void Debug<T1, T2>(string format, T1 parameter1, T2 parameter2)
        {
            DebugMessage().Log(format, parameter1, parameter2);
        }

        [MessageTemplateFormatMethod(FormatParameterName)]
        [Conditional(LoggerStaticData.ConditionalName)]
        public static void Debug<T1, T2, T3>(string format, T1 parameter1, T2 parameter2, T3 parameter3)
        {
            DebugMessage().Log(format, parameter1, parameter2, parameter3);
        }
        
        [MessageTemplateFormatMethod(FormatParameterName)]
        [Conditional(LoggerStaticData.ConditionalName)]
        public static void Debug(string format, params object[] parameters)
        {
            DebugMessage().Log(format, parameters);
        }
        
        [Conditional(LoggerStaticData.ConditionalName)]
        public static void Warning(string message)
        {
            WarningMessage().Log(message);
        }

        [MessageTemplateFormatMethod(FormatParameterName)]
        [Conditional(LoggerStaticData.ConditionalName)]
        public static void Warning<T>(string format, T parameter1)
        {
            WarningMessage().Log(format, parameter1);
        }

        [MessageTemplateFormatMethod(FormatParameterName)]
        [Conditional(LoggerStaticData.ConditionalName)]
        public static void Warning<T1, T2>(string format, T1 parameter1, T2 parameter2)
        {
            WarningMessage().Log(format, parameter1, parameter2);
        }

        [MessageTemplateFormatMethod(FormatParameterName)]
        [Conditional(LoggerStaticData.ConditionalName)]
        public static void Warning<T1, T2, T3>(string format, T1 parameter1, T2 parameter2, T3 parameter3)
        {
            WarningMessage().Log(format, parameter1, parameter2, parameter3);
        }

        [MessageTemplateFormatMethod(FormatParameterName)]
        [Conditional(LoggerStaticData.ConditionalName)]
        public static void Warning(string format, params object[] parameters)
        {
            WarningMessage().Log(format, parameters);
        }
        
        [Conditional(LoggerStaticData.ConditionalName)]
        public static void Error(string message)
        {
            ErrorMessage().Log(message);
        }

        [MessageTemplateFormatMethod(FormatParameterName)]
        [Conditional(LoggerStaticData.ConditionalName)]
        public static void Error<T>(string format, T parameter1)
        {
            ErrorMessage().Log(format, parameter1);
        }

        [MessageTemplateFormatMethod(FormatParameterName)]
        [Conditional(LoggerStaticData.ConditionalName)]
        public static void Error<T1, T2>(string format, T1 parameter1, T2 parameter2)
        {
            ErrorMessage().Log(format, parameter1, parameter2);
        }

        [MessageTemplateFormatMethod(FormatParameterName)]
        [Conditional(LoggerStaticData.ConditionalName)]
        public static void Error<T1, T2, T3>(string format, T1 parameter1, T2 parameter2, T3 parameter3)
        {
            ErrorMessage().Log(format, parameter1, parameter2, parameter3);
        }

        [MessageTemplateFormatMethod(FormatParameterName)]
        [Conditional(LoggerStaticData.ConditionalName)]
        public static void Error(string format, params object[] parameters)
        {
            ErrorMessage().Log(format, parameters);
        }
        
        [Conditional(LoggerStaticData.ConditionalName)]
        public static void Fatal(string message)
        {
            FatalMessage().Log(message);
        }

        [MessageTemplateFormatMethod(FormatParameterName)]
        [Conditional(LoggerStaticData.ConditionalName)]
        public static void Fatal<T>(string format, T parameter1)
        {
            FatalMessage().Log(format, parameter1);
        }

        [MessageTemplateFormatMethod(FormatParameterName)]
        [Conditional(LoggerStaticData.ConditionalName)]
        public static void Fatal<T1, T2>(string format, T1 parameter1, T2 parameter2)
        {
            FatalMessage().Log(format, parameter1, parameter2);
        }

        [MessageTemplateFormatMethod(FormatParameterName)]
        [Conditional(LoggerStaticData.ConditionalName)]
        public static void Fatal<T1, T2, T3>(string format, T1 parameter1, T2 parameter2, T3 parameter3)
        {
            FatalMessage().Log(format, parameter1, parameter2, parameter3);
        }

        [MessageTemplateFormatMethod(FormatParameterName)]
        [Conditional(LoggerStaticData.ConditionalName)]
        public static void Fatal(string format, params object[] parameters)
        {
            FatalMessage().Log(format, parameters);
        }

        public static LogMessage DebugMessage(string tag = null, Exception exception = null)
        {
            return Logger.CreateMessage(LogLevel.Debug, tag, exception);
        }

        public static LogMessage WarningMessage(string tag = null, Exception exception = null)
        {
            return Logger.CreateMessage(LogLevel.Warning, tag, exception);
        }

        public static LogMessage ErrorMessage(string tag = null, Exception exception = null)
        {
            return Logger.CreateMessage(LogLevel.Error, tag, exception);
        }

        public static LogMessage FatalMessage(string tag = null, Exception exception = null)
        {
            return Logger.CreateMessage(LogLevel.Fatal, tag, exception);
        }
    }
}