using System;
using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Destinations.UnityDebug.Extensions;
using OpenMyGame.LoggerUnity.Destinations.UnityDebug.PartLogging;
using OpenMyGame.LoggerUnity.Infrastructure.StringBuilders;
using OpenMyGame.LoggerUnity.Messages;
using OpenMyGame.LoggerUnity.Messages.Exceptions;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.Destinations.UnityDebug
{
    internal class UnityDebugLogDestination : LogDestination<UnityDebugLogConfiguration>
    {
        private const string Format = "{0}";

        private PartLoggingMessageFormat _partLoggingMessageFormat;
        
        protected override void OnInitializing()
        {
            _partLoggingMessageFormat = new PartLoggingMessageFormat(Configuration.MessagePartFormat);
        }

        protected override void LogRenderedMessage(in LogMessage logMessage, ref ValueStringBuilder renderedMessage)
        {
            var logType = LogLevelToLogTypeConverter.Convert(logMessage.LogLevel);
            
            switch (logType)
            {
                case LogType.Exception:
                    LogException(new LogException(renderedMessage.ToString()));
                    break;
                case LogType.Error:
                case LogType.Assert:
                case LogType.Warning:
                case LogType.Log:
                default:
                    LogMessage(logType, logMessage, ref renderedMessage);
                    break;
            }
        }

        private void LogMessage(LogType logType, LogMessage logMessage, ref ValueStringBuilder renderedMessage)
        {
            if (renderedMessage.Length <= Configuration.MessagePartMaxSize)
            {
                Log(logType, ref renderedMessage);
                return;
            }
            
            LogMessageByParts(logType, logMessage, ref renderedMessage);
        }

        private void LogMessageByParts(LogType logType, LogMessage logMessage, ref ValueStringBuilder renderedMessage)
        {
            var offset = 0;
            var maxSize = Configuration.MessagePartMaxSize;
            var memory = renderedMessage.AsMemory();
            var partsCount = Mathf.CeilToInt((float)renderedMessage.Length / maxSize);
            var parameters = new PartLoggingParameters(logMessage.Id, partsCount);
            
            while (offset < renderedMessage.Length)
            {
                var endIndex = offset + maxSize >= memory.Length ? memory.Length : offset + maxSize;
                var messagePart = memory[offset..endIndex];
                
                parameters.IncrementPartIndex();
                parameters.UpdateMessage(messagePart);

                var renderedMessagePart = _partLoggingMessageFormat.CreatePart(ref parameters);
                Log(logType, ref renderedMessagePart);
                renderedMessagePart.Dispose();
                
                offset += maxSize;
            }
        }

        private void Log(LogType logType, ref ValueStringBuilder message)
        {
            var logOption = Configuration.IsUnityStacktraceEnabled ? LogOption.None : LogOption.NoStacktrace;
            Debug.LogFormat(logType, logOption, null, Format, message.AsMemory());
        }

        private static void LogException(Exception exception)
        {
            Debug.LogException(exception);
        }
    }
}