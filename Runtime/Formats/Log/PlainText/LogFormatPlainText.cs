using System;
using System.Collections.Generic;
using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Infrastructure.StringBuilders;
using OpenMyGame.LoggerUnity.Messages;
using OpenMyGame.LoggerUnity.Parameters.Log.Base;
using OpenMyGame.LoggerUnity.Parameters.Log.Processors;
using OpenMyGame.LoggerUnity.Parsing.Models;

namespace OpenMyGame.LoggerUnity.Formats.Log.PlainText
{
    internal class LogFormatPlainText : ILogFormat
    {
        private readonly MessagePart[] _messageParts;
        private readonly Dictionary<string, ILogFormatParameter> _logFormatParameters;
        private readonly ILogParameterProcessor _processor;

        public LogFormatPlainText(
            MessagePart[] messageParts,
            Dictionary<string, ILogFormatParameter> logFormatParameters,
            ILogParameterProcessor processor)
        {
            _messageParts = messageParts;
            _logFormatParameters = logFormatParameters;
            _processor = processor;
        }
        
        public void Render(
            ref ValueStringBuilder destination, in LogMessage logMessage, 
            ref LogMessageRenderData messageRenderData, in ReadOnlySpan<byte> stacktrace)
        {
            RenderLogMessage(ref destination, in logMessage, ref messageRenderData);
            TryAppendStacktrace(ref destination, stacktrace);
        }

        private void RenderLogMessage(
            ref ValueStringBuilder destination, in LogMessage logMessage, ref LogMessageRenderData messageRenderData)
        {
            foreach (var messagePart in _messageParts.AsSpan())
            {
                Render(ref destination, messagePart, in logMessage, ref messageRenderData);
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
                _processor.Preprocess(ref destination, messagePart, property.GetValue(message));
                property.Render(ref destination, messagePart, message);
                _processor.Postprocess(ref destination, messagePart);
            }
        }

        private static void TryAppendStacktrace(ref ValueStringBuilder destination, in ReadOnlySpan<byte> stacktrace)
        {
            if (stacktrace.IsEmpty)
            {
                return;
            }
            
            if (destination[^1] != '\n')
            {
                destination.AppendLine();
            }
                
            destination.AppendEncodedBytes(stacktrace);
        }
    }
}