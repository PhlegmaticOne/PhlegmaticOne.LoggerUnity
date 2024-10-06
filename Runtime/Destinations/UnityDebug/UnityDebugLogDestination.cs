using System;
using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Destinations.UnityDebug.Extensions;
using OpenMyGame.LoggerUnity.Destinations.UnityDebug.PartLogging;
using OpenMyGame.LoggerUnity.Messages;
using OpenMyGame.LoggerUnity.Messages.Exceptions;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.Destinations.UnityDebug
{
    public class UnityDebugLogDestination : LogDestination<UnityDebugLogConfiguration>
    {
        private const string Format = "{0}";

        private PartLoggingMessageFormat _partLoggingMessageFormat;
        
        public override string DestinationName => LogDestinationsSupported.Debug;
        
        protected override void OnInitializing()
        {
            _partLoggingMessageFormat = new PartLoggingMessageFormat(Configuration.MessagePartFormat);
        }

        protected override void LogRenderedMessage(LogMessage logMessage, string renderedMessage, Span<object> parameters)
        {
            var logType = LogLevelToLogTypeConverter.Convert(logMessage.LogLevel);
            
            switch (logType)
            {
                case LogType.Exception:
                    LogException(new LogException(renderedMessage));
                    break;
                case LogType.Error:
                case LogType.Assert:
                case LogType.Warning:
                case LogType.Log:
                default:
                    LogMessage(logType, logMessage, renderedMessage);
                    break;
            }
        }

        private void LogMessage(LogType logType, LogMessage logMessage, string renderedMessage)
        {
            if (renderedMessage.Length <= Configuration.MessagePartMaxSize)
            {
                Log(logType, renderedMessage);
                return;
            }
            
            LogMessageByParts(logType, logMessage, renderedMessage);
        }

        private void LogMessageByParts(LogType logType, LogMessage logMessage, string renderedMessage)
        {
            var offset = 0;
            var maxSize = Configuration.MessagePartMaxSize;
            var messageSpan = renderedMessage.AsSpan();
            var partsCount = Mathf.CeilToInt((float)renderedMessage.Length / maxSize);
            var parameters = new PartLoggingParameters(logMessage.Id, partsCount);

            while (offset < renderedMessage.Length)
            {
                var endIndex = offset + maxSize >= messageSpan.Length ? messageSpan.Length : offset + maxSize;
                var messagePart = messageSpan[offset..endIndex].ToString();
                
                parameters.IncrementPartIndex();
                parameters.UpdateMessage(messagePart);

                var renderedMessagePart = _partLoggingMessageFormat.CreatePart(parameters);
                Log(logType, renderedMessagePart);
                
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