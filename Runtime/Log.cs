using System;
using System.Diagnostics;
using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Messages;

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
                    DisposeCurrentLogger();
                }

                SetNewLogger(value);
            }
        }

        public static event Action<LogMessageDestinationLoggedEventArgs> MessageToDestinationLogged;
        public static event Action<LogMessage> MessageLogged;

        public static void SetDestinationEnabled(string destinationName, bool isEnabled)
        {
            Logger.SetDestinationEnabled(destinationName, isEnabled);
        }

        public static LogMessage DebugMessage() => Logger.CreateMessage(LogLevel.Debug, stacktraceDepthLevel: 0);
        public static LogMessage WarningMessage() => Logger.CreateMessage(LogLevel.Warning, stacktraceDepthLevel: 0);
        public static LogMessage ErrorMessage() => Logger.CreateMessage(LogLevel.Error, stacktraceDepthLevel: 0);
        public static LogMessage FatalMessage() => Logger.CreateMessage(LogLevel.Fatal, stacktraceDepthLevel: 0);

        [Conditional(LoggerStaticData.ConditionalName)]
        public static void Exception(Exception exception)
        {
            if (Logger is null || !Logger.IsEnabled || exception is null)
            {
                return;
            }

            Logger.CreateMessage(LogLevel.Fatal, stacktraceDepthLevel: 0)
                .WithException(exception)
                .Log(LoggerStaticData.ExceptionPlaceholderFormat, LoggerStaticData.ExceptionPlaceholder);
        }

        private static void SetNewLogger(ILogger logger)
        {
            LoggerPrivate = logger;
            LoggerPrivate.MessageToDestinationLogged += OnMessageToDestinationLogged;
            LoggerPrivate.MessageLogged += OnMessageLogged;
        }

        private static void DisposeCurrentLogger()
        {
            LoggerPrivate.MessageToDestinationLogged -= OnMessageToDestinationLogged;
            LoggerPrivate.MessageLogged -= OnMessageLogged;
            LoggerPrivate.Dispose();
        }

        private static void OnMessageLogged(LogMessage logMessage)
        {
            MessageLogged?.Invoke(logMessage);
        }

        private static void OnMessageToDestinationLogged(LogMessageDestinationLoggedEventArgs messageDestinationLoggedEventArgs)
        {
            MessageToDestinationLogged?.Invoke(messageDestinationLoggedEventArgs);
        }
    }
}