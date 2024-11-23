using System;
using System.Diagnostics;
using OpenMyGame.LoggerUnity.Configuration;
using OpenMyGame.LoggerUnity.Infrastructure.Attributes;
using OpenMyGame.LoggerUnity.Messages;

namespace OpenMyGame.LoggerUnity
{
    public readonly struct LogWithTag
    {
        private const string FormatParameterName = "format";

        private readonly string _tag;

        public LogWithTag(string tag)
        {
            _tag = tag;
        }

        [Conditional(LoggerConfigurationData.ConditionalName)]
        public void Exception(Exception exception)
        {
            if (!Log.Logger.IsEnabled || exception is null)
            {
                return;
            }
            
            FatalMessage(exception).Log(
                LoggerConfigurationData.ExceptionPlaceholderFormat, LoggerConfigurationData.ExceptionPlaceholder);
        }

        [Conditional(LoggerConfigurationData.ConditionalName)]
        public void Debug(string message)
        {
            DebugMessage().Log(message);
        }

        [MessageTemplateFormatMethod(FormatParameterName)]
        [Conditional(LoggerConfigurationData.ConditionalName)]
        public void Debug<T>(string format, T parameter1)
        {
            DebugMessage().Log(format, parameter1);
        }

        [MessageTemplateFormatMethod(FormatParameterName)]
        [Conditional(LoggerConfigurationData.ConditionalName)]
        public void Debug<T1, T2>(string format, T1 parameter1, T2 parameter2)
        {
            DebugMessage().Log(format, parameter1, parameter2);
        }

        [MessageTemplateFormatMethod(FormatParameterName)]
        [Conditional(LoggerConfigurationData.ConditionalName)]
        public void Debug<T1, T2, T3>(string format, T1 parameter1, T2 parameter2, T3 parameter3)
        {
            DebugMessage().Log(format, parameter1, parameter2, parameter3);
        }

        [MessageTemplateFormatMethod(FormatParameterName)]
        [Conditional(LoggerConfigurationData.ConditionalName)]
        public void Debug(string format, params object[] parameters)
        {
            DebugMessage().Log(format, parameters);
        }

        [Conditional(LoggerConfigurationData.ConditionalName)]
        public void Warning(string message)
        {
            WarningMessage().Log(message);
        }

        [MessageTemplateFormatMethod(FormatParameterName)]
        [Conditional(LoggerConfigurationData.ConditionalName)]
        public void Warning<T>(string format, T parameter1)
        {
            WarningMessage().Log(format, parameter1);
        }

        [MessageTemplateFormatMethod(FormatParameterName)]
        [Conditional(LoggerConfigurationData.ConditionalName)]
        public void Warning<T1, T2>(string format, T1 parameter1, T2 parameter2)
        {
            WarningMessage().Log(format, parameter1, parameter2);
        }

        [MessageTemplateFormatMethod(FormatParameterName)]
        [Conditional(LoggerConfigurationData.ConditionalName)]
        public void Warning<T1, T2, T3>(string format, T1 parameter1, T2 parameter2, T3 parameter3)
        {
            WarningMessage().Log(format, parameter1, parameter2, parameter3);
        }

        [MessageTemplateFormatMethod(FormatParameterName)]
        [Conditional(LoggerConfigurationData.ConditionalName)]
        public void Warning(string format, params object[] parameters)
        {
            WarningMessage().Log(format, parameters);
        }

        [Conditional(LoggerConfigurationData.ConditionalName)]
        public void Error(string message)
        {
            ErrorMessage().Log(message);
        }

        [MessageTemplateFormatMethod(FormatParameterName)]
        [Conditional(LoggerConfigurationData.ConditionalName)]
        public void Error<T>(string format, T parameter1)
        {
            ErrorMessage().Log(format, parameter1);
        }

        [MessageTemplateFormatMethod(FormatParameterName)]
        [Conditional(LoggerConfigurationData.ConditionalName)]
        public void Error<T1, T2>(string format, T1 parameter1, T2 parameter2)
        {
            ErrorMessage().Log(format, parameter1, parameter2);
        }

        [MessageTemplateFormatMethod(FormatParameterName)]
        [Conditional(LoggerConfigurationData.ConditionalName)]
        public void Error<T1, T2, T3>(string format, T1 parameter1, T2 parameter2, T3 parameter3)
        {
            ErrorMessage().Log(format, parameter1, parameter2, parameter3);
        }

        [MessageTemplateFormatMethod(FormatParameterName)]
        [Conditional(LoggerConfigurationData.ConditionalName)]
        public void Error(string format, params object[] parameters)
        {
            ErrorMessage().Log(format, parameters);
        }

        [Conditional(LoggerConfigurationData.ConditionalName)]
        public void Fatal(string message)
        {
            FatalMessage().Log(message);
        }

        [MessageTemplateFormatMethod(FormatParameterName)]
        [Conditional(LoggerConfigurationData.ConditionalName)]
        public void Fatal<T>(string format, T parameter1)
        {
            FatalMessage().Log(format, parameter1);
        }

        [MessageTemplateFormatMethod(FormatParameterName)]
        [Conditional(LoggerConfigurationData.ConditionalName)]
        public void Fatal<T1, T2>(string format, T1 parameter1, T2 parameter2)
        {
            FatalMessage().Log(format, parameter1, parameter2);
        }

        [MessageTemplateFormatMethod(FormatParameterName)]
        [Conditional(LoggerConfigurationData.ConditionalName)]
        public void Fatal<T1, T2, T3>(string format, T1 parameter1, T2 parameter2, T3 parameter3)
        {
            FatalMessage().Log(format, parameter1, parameter2, parameter3);
        }

        [MessageTemplateFormatMethod(FormatParameterName)]
        [Conditional(LoggerConfigurationData.ConditionalName)]
        public void Fatal(string format, params object[] parameters)
        {
            ErrorMessage().Log(format, parameters);
        }

        public LogMessage DebugMessage(Exception exception = null)
        {
            return Log.Logger.CreateMessage(LogLevel.Debug, _tag, exception);
        }

        public LogMessage WarningMessage(Exception exception = null)
        {
            return Log.Logger.CreateMessage(LogLevel.Warning, _tag, exception);
        }

        public LogMessage ErrorMessage(Exception exception = null)
        {
            return Log.Logger.CreateMessage(LogLevel.Error, _tag, exception);
        }

        public LogMessage FatalMessage(Exception exception = null)
        {
            return Log.Logger.CreateMessage(LogLevel.Fatal, _tag, exception);
        }
    }
}