using System;
using OpenMyGame.LoggerUnity.Runtime.Base;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.Runtime.UnityDebug
{
    public class UnityDebugDestination : LogDestination<UnityDebugConfiguration>
    {
        private const string Format = "{0}";
        public override string DestinationName => "Debug";

        protected override void LogRenderedMessage(LogMessage logMessage, string renderedMessage)
        {
            var logType = ConvertToUnityLogType(logMessage.LogLevel);
            
            switch (logType)
            {
                case LogType.Exception when logMessage.Exception is not null:
                    LogException(logMessage.Exception);
                    break;
                case LogType.Exception when logMessage.Exception is null:
                    LogException(new LogException(renderedMessage));
                    break;
                case LogType.Error:
                case LogType.Assert:
                case LogType.Warning:
                case LogType.Log:
                default:
                    LogMessage(logType, renderedMessage);
                    break;
            }
        }

        private static void LogMessage(LogType logType, string renderedMessage)
        {
            Debug.LogFormat(logType, LogOption.NoStacktrace, null, Format, renderedMessage);
        }

        private static void LogException(Exception exception)
        {
            Debug.LogException(exception);
        }

        private static LogType ConvertToUnityLogType(LogLevel logLevel)
        {
            return logLevel switch
            {
                LogLevel.Debug => LogType.Log,
                LogLevel.Warning => LogType.Warning,
                LogLevel.Error => LogType.Error,
                LogLevel.Fatal => LogType.Exception,
                _ => throw new ArgumentOutOfRangeException(nameof(logLevel), logLevel, null)
            };
        }
    }
}