using System;
using System.Collections.Generic;
using System.Text;
using OpenMyGame.LoggerUnity.Messages;
using OpenMyGame.LoggerUnity.Parameters.Log.Base;
using OpenMyGame.LoggerUnity.Parameters.Log.Processors;
using OpenMyGame.LoggerUnity.Parsing.Models;

namespace OpenMyGame.LoggerUnity.Parameters.Log.Formats
{
    public class LogFormat : ILogFormat
    {
        private readonly bool _appendStacktraceToRenderingMessage;
        private readonly MessagePart[] _messageParts;
        private readonly Dictionary<string, ILogFormatParameter> _logFormatParameters;
        private readonly ILogParameterPostRenderProcessor _postRenderProcessor;

        public LogFormat(
            bool appendStacktraceToRenderingMessage, 
            MessagePart[] messageParts, 
            Dictionary<string, ILogFormatParameter> logFormatParameters,
            ILogParameterPostRenderProcessor postRenderProcessor)
        {
            _appendStacktraceToRenderingMessage = appendStacktraceToRenderingMessage;
            _messageParts = messageParts;
            _logFormatParameters = logFormatParameters;
            _postRenderProcessor = postRenderProcessor;
        }
        
        public string Render(LogMessage logMessage, string renderedMessage)
        {
            var logBuilder = new StringBuilder();
            RenderLogMessage(logMessage, renderedMessage, logBuilder);
            TryAppendStacktrace(logBuilder, logMessage);
            return logBuilder.ToString();
        }

        private void RenderLogMessage(LogMessage logMessage, string renderedMessage, StringBuilder logBuilder)
        {
            foreach (var messagePart in _messageParts)
            {
                var renderMessagePart = Render(messagePart, logMessage, renderedMessage);

                if (messagePart.IsParameter)
                {
                    _postRenderProcessor.Process(logBuilder, messagePart, renderMessagePart);
                }
                else
                {
                    logBuilder.Append(renderMessagePart);
                }
            }
        }

        private void TryAppendStacktrace(StringBuilder destination, LogMessage logMessage)
        {
            if (_appendStacktraceToRenderingMessage && 
                logMessage.HasStacktrace() &&
                logMessage.Stacktrace.TryGetUserCodeStacktrace(out var userCodeStacktrace))
            {
                if (destination[^1] != '\n')
                {
                    destination.AppendLine();
                }
                
                destination.Append(userCodeStacktrace);
            }
        }

        private ReadOnlySpan<char> Render(MessagePart messagePart, LogMessage message, string renderedMessage)
        {
            messagePart.SplitParameterToValueAndFormat(out var parameterValue, out _);
            var property = _logFormatParameters.GetValueOrDefault(parameterValue.ToString());
            return property is null ? parameterValue : property.GetValue(messagePart, message, renderedMessage);
        }
    }
}