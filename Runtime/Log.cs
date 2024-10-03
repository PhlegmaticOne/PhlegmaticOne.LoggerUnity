using System;
using System.Diagnostics;
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

        public static event Action<LogMessageLoggedEventArgs> MessageLogged;

        public static void SetDestinationEnabled(string destinationName, bool isEnabled)
        {
            Logger.SetDestinationEnabled(destinationName, isEnabled);
        }

        public static LogMessage DebugMessage() => Message(LogLevel.Debug);
        public static LogMessage WarningMessage() => Message(LogLevel.Warning);
        public static LogMessage ErrorMessage() => Message(LogLevel.Error);
        public static LogMessage FatalMessage() => Message(LogLevel.Fatal);

        [Conditional(LoggerStaticData.ConditionalName)]
        public static void Exception(Exception exception)
        {
            if (Logger is null || !Logger.IsEnabled || exception is null)
            {
                return;
            }

            FatalMessage()
                .WithException(exception)
                .Log(LoggerStaticData.ExceptionFormat);
        }

        private static LogMessage Message(LogLevel logLevel) => new(logLevel, Logger);

        private static void OnMessageLogged(LogMessageLoggedEventArgs messageLoggedEventArgs)
        {
            MessageLogged?.Invoke(messageLoggedEventArgs);
        }
    }
}