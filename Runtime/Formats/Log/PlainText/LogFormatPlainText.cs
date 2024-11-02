using System;
using System.Collections.Generic;
using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Messages;
using OpenMyGame.LoggerUnity.Parameters.Log.Base;
using OpenMyGame.LoggerUnity.Parameters.Log.Processors;
using OpenMyGame.LoggerUnity.Parsing.Models;
using SpanUtilities.StringBuilders;

namespace OpenMyGame.LoggerUnity.Formats.Log.PlainText
{
    internal class LogFormatPlainText : ILogFormat
    {
        private readonly bool _appendStacktraceToRenderingMessage;
        private readonly MessagePart[] _messageParts;
        private readonly Dictionary<string, ILogFormatParameter> _logFormatParameters;
        private readonly ILogParameterPostRenderer _postRenderer;

        public LogFormatPlainText(
            MessagePart[] messageParts,
            bool appendStacktraceToRenderingMessage, 
            Dictionary<string, ILogFormatParameter> logFormatParameters,
            ILogParameterPostRenderer postRenderer)
        {
            _appendStacktraceToRenderingMessage = appendStacktraceToRenderingMessage;
            _messageParts = messageParts;
            _logFormatParameters = logFormatParameters;
            _postRenderer = postRenderer;
        }
        
        public void Render(
            ref ValueStringBuilder destination, in LogMessage logMessage, ref LogMessageRenderData messageRenderData)
        {
            RenderLogMessage(ref destination, in logMessage, ref messageRenderData);
            TryAppendStacktrace(ref destination, logMessage);
        }

        private void RenderLogMessage(
            ref ValueStringBuilder destination, in LogMessage logMessage, ref LogMessageRenderData messageRenderData)
        {
            foreach (var messagePart in _messageParts.AsSpan())
            {
                Render(ref destination, messagePart, in logMessage, ref messageRenderData);
            }
        }

        private void TryAppendStacktrace(ref ValueStringBuilder destination, in LogMessage logMessage)
        {
            if (_appendStacktraceToRenderingMessage && 
                logMessage.Stacktrace.TryGetUserCodeStacktrace(out var userCodeStacktrace))
            {
                if (destination[^1] != '\n')
                {
                    destination.AppendLine();
                }
                
                destination.Append(userCodeStacktrace);
            }
        }

        private void Render(
            ref ValueStringBuilder destination, in MessagePart messagePart, in LogMessage message,
            ref LogMessageRenderData messageRenderData)
        {
            messagePart.SplitParameterToValueAndFormat(out var parameterValue, out _);

            if (parameterValue.IsEmpty)
            {
                return;
            }
            
            if (!messagePart.IsParameter)
            {
                destination.Append(parameterValue);
                return;
            }

            if (parameterValue.SequenceEqual(LoggerStaticData.MessageParameterKey))
            {
                messageRenderData.Render(ref destination);
                return;
            }
            
            var property = _logFormatParameters.GetValueOrDefault(parameterValue.ToString());

            if (!property.IsEmpty(message))
            {
                _postRenderer.Preprocess(ref destination, messagePart, property.GetValue(message));
                property.Render(ref destination, messagePart, message);
                _postRenderer.Postprocess(ref destination, messagePart);
            }
        }
    }
}