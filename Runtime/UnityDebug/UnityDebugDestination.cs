using System;
using OpenMyGame.LoggerUnity.Runtime.Base;
using OpenMyGame.LoggerUnity.Runtime.Messages;
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
            Debug.LogFormat(logType, LogOption.NoStacktrace, null, Format, renderedMessage);
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