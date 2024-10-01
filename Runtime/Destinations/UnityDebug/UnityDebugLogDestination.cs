using System;
using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Destinations.UnityDebug.Extensions;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.Destinations.UnityDebug
{
    public class UnityDebugLogDestination : LogDestination<UnityDebugLogConfiguration>
    {
        internal const string Destination = "Debug";
        
        private const string Format = "{0}";
        public override string DestinationName => Destination;

        protected override void LogRenderedMessage(LogMessage logMessage, string renderedMessage, Span<object> parameters)
        {
            var logType = LogLevelToLogTypeConverter.Convert(logMessage.LogLevel);
            
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

        private void LogMessage(LogType logType, string renderedMessage)
        {
            if (renderedMessage.Length <= Configuration.MessagePartMaxSize)
            {
                Log(logType, renderedMessage);
                return;
            }
            
            LogMessageByParts(logType, renderedMessage);
        }

        private void LogMessageByParts(LogType logType, string renderedMessage)
        {
            var offset = 0;
            var maxSize = Configuration.MessagePartMaxSize;
            var messageSpan = renderedMessage.AsSpan();

            while (offset < renderedMessage.Length)
            {
                var endIndex = offset + maxSize >= messageSpan.Length ? messageSpan.Length : offset + maxSize;
                var messagePart = messageSpan[offset..endIndex];
                Log(logType, messagePart.ToString());
                offset += maxSize;
            }
        }

        private void Log(LogType logType, string message)
        {
            var logOption = Configuration.IsUnityStacktraceEnabled ? LogOption.None : LogOption.NoStacktrace;
            Debug.LogFormat(logType, logOption, null, Format, message);
        }

        private static void LogException(Exception exception)
        {
            Debug.LogException(exception);
        }
    }
}