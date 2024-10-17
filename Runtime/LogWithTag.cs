using System;
using System.Diagnostics;
using OpenMyGame.LoggerUnity.Attributes;
using OpenMyGame.LoggerUnity.Base;
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

        [Conditional(LoggerStaticData.ConditionalName)]
        public void Exception(Exception exception)
        {
            Log.Logger.CreateMessage(LogLevel.Fatal, stacktraceDepthLevel: 1)
                .WithTag(_tag)
                .WithException(exception)
                .Log(LoggerStaticData.ExceptionPlaceholderFormat, LoggerStaticData.ExceptionPlaceholder);
        }
        
        [Conditional(LoggerStaticData.ConditionalName)]
        public void Debug(string message)
        {
            DebugMessage().Log(message);
        }
        
        [MessageTemplateFormatMethod(FormatParameterName)]
        [Conditional(LoggerStaticData.ConditionalName)]
        public void Debug<T>(string format, T parameter1)
        {
            DebugMessage().Log(format, parameter1);
        }
        
        [MessageTemplateFormatMethod(FormatParameterName)]
        [Conditional(LoggerStaticData.ConditionalName)]
        public void Debug<T1, T2>(string format, T1 parameter1, T2 parameter2)
        {
            DebugMessage().Log(format, parameter1, parameter2);
        }

        [MessageTemplateFormatMethod(FormatParameterName)]
        [Conditional(LoggerStaticData.ConditionalName)]
        public void Debug<T1, T2, T3>(string format, T1 parameter1, T2 parameter2, T3 parameter3)
        {
            DebugMessage().Log(format, parameter1, parameter2, parameter3);
        }
        
        [MessageTemplateFormatMethod(FormatParameterName)]
        [Conditional(LoggerStaticData.ConditionalName)]
        public void Debug(string format, params object[] parameters)
        {
            DebugMessage().Log(format, parameters);
        }
        
        [Conditional(LoggerStaticData.ConditionalName)]
        public void Warning(string message)
        {
            WarningMessage().Log(message);
        }

        [MessageTemplateFormatMethod(FormatParameterName)]
        [Conditional(LoggerStaticData.ConditionalName)]
        public void Warning<T>(string format, T parameter1)
        {
            WarningMessage().Log(format, parameter1);
        }

        [MessageTemplateFormatMethod(FormatParameterName)]
        [Conditional(LoggerStaticData.ConditionalName)]
        public void Warning<T1, T2>(string format, T1 parameter1, T2 parameter2)
        {
            WarningMessage().Log(format, parameter1, parameter2);
        }

        [MessageTemplateFormatMethod(FormatParameterName)]
        [Conditional(LoggerStaticData.ConditionalName)]
        public void Warning<T1, T2, T3>(string format, T1 parameter1, T2 parameter2, T3 parameter3)
        {
            WarningMessage().Log(format, parameter1, parameter2, parameter3);
        }

        [MessageTemplateFormatMethod(FormatParameterName)]
        [Conditional(LoggerStaticData.ConditionalName)]
        public void Warning(string format, params object[] parameters)
        {
            WarningMessage().Log(format, parameters);
        }
        
        [Conditional(LoggerStaticData.ConditionalName)]
        public void Error(string message)
        {
            ErrorMessage().Log(message);
        }

        [MessageTemplateFormatMethod(FormatParameterName)]
        [Conditional(LoggerStaticData.ConditionalName)]
        public void Error<T>(string format, T parameter1)
        {
            ErrorMessage().Log(format, parameter1);
        }

        [MessageTemplateFormatMethod(FormatParameterName)]
        [Conditional(LoggerStaticData.ConditionalName)]
        public void Error<T1, T2>(string format, T1 parameter1, T2 parameter2)
        {
            ErrorMessage().Log(format, parameter1, parameter2);
        }

        [MessageTemplateFormatMethod(FormatParameterName)]
        [Conditional(LoggerStaticData.ConditionalName)]
        public void Error<T1, T2, T3>(string format, T1 parameter1, T2 parameter2, T3 parameter3)
        {
            ErrorMessage().Log(format, parameter1, parameter2, parameter3);
        }

        [MessageTemplateFormatMethod(FormatParameterName)]
        [Conditional(LoggerStaticData.ConditionalName)]
        public void Error(string format, params object[] parameters)
        {
            ErrorMessage().Log(format, parameters);
        }
        
        [Conditional(LoggerStaticData.ConditionalName)]
        public void Fatal(string message)
        {
            FatalMessage().Log(message);
        }

        [MessageTemplateFormatMethod(FormatParameterName)]
        [Conditional(LoggerStaticData.ConditionalName)]
        public void Fatal<T>(string format, T parameter1)
        {
            FatalMessage().Log(format, parameter1);
        }

        [MessageTemplateFormatMethod(FormatParameterName)]
        [Conditional(LoggerStaticData.ConditionalName)]
        public void Fatal<T1, T2>(string format, T1 parameter1, T2 parameter2)
        {
            FatalMessage().Log(format, parameter1, parameter2);
        }

        [MessageTemplateFormatMethod(FormatParameterName)]
        [Conditional(LoggerStaticData.ConditionalName)]
        public void Fatal<T1, T2, T3>(string format, T1 parameter1, T2 parameter2, T3 parameter3)
        {
            FatalMessage().Log(format, parameter1, parameter2, parameter3);
        }
        
        [MessageTemplateFormatMethod(FormatParameterName)]
        [Conditional(LoggerStaticData.ConditionalName)]
        public void Fatal(string format, params object[] parameters)
        {
            ErrorMessage().Log(format, parameters);
        }

        public LogMessage DebugMessage()
        {
            return Log.Logger
                .CreateMessage(LogLevel.Debug, stacktraceDepthLevel: 1)
                .WithTag(_tag);
        }

        public LogMessage WarningMessage()
        {
            return Log.Logger
                .CreateMessage(LogLevel.Warning, stacktraceDepthLevel: 1)
                .WithTag(_tag);
        }

        public LogMessage ErrorMessage()
        {
            return Log.Logger
                .CreateMessage(LogLevel.Error, stacktraceDepthLevel: 1)
                .WithTag(_tag);
        }

        public LogMessage FatalMessage()
        {
            return Log.Logger
                .CreateMessage(LogLevel.Fatal, stacktraceDepthLevel: 1)
                .WithTag(_tag);
        }
    }
}