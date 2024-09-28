using System;
using System.Diagnostics;
using OpenMyGame.LoggerUnity.Attributes;
using OpenMyGame.LoggerUnity.Base;

namespace OpenMyGame.LoggerUnity
{
    public static class Log
    {
        private static ILogger LoggerPrivate;

        public static ILogger Logger
        {
            get => LoggerPrivate;
            set
            {
                if (LoggerPrivate is not null)
                {
                    LoggerPrivate.MessageLogged -= OnMessageLogged;
                    LoggerPrivate.Dispose();
                }

                LoggerPrivate = value;
                LoggerPrivate.MessageLogged += OnMessageLogged;
            }
        }

        public static event Action<LogMessage> MessageLogged;

        public static void SetDestinationEnabled(string destinationName, bool isEnabled)
        {
            Logger.SetDestinationEnabled(destinationName, isEnabled);
        }

        public static LogMessage DebugMessage() => Message(LogLevel.Debug);
        public static LogMessage WarningMessage() => Message(LogLevel.Warning);
        public static LogMessage ErrorMessage() => Message(LogLevel.Error);
        public static LogMessage FatalMessage() => Message(LogLevel.Fatal);

        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public static void Exception(Exception exception)
        {
            if (Logger is null || !Logger.IsEnabled || exception is null)
            {
                return;
            }

            FatalMessage()
                .WithException(exception)
                .Log("{Exception}");
        }

        private static LogMessage Message(LogLevel logLevel)
        {
            return new LogMessage(logLevel, Logger);
        }

        private static void OnMessageLogged(LogMessage obj)
        {
            MessageLogged?.Invoke(obj);
        }
    }
}