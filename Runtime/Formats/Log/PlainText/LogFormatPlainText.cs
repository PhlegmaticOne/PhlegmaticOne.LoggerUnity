using System;
using System.Collections.Generic;
using Openmygame.Logger.Configuration;
using Openmygame.Logger.Infrastructure.StringBuilders;
using Openmygame.Logger.Messages;
using Openmygame.Logger.Parameters.Log.Base;
using Openmygame.Logger.Parameters.Log.Processors;
using Openmygame.Logger.Parsing.Models;

namespace Openmygame.Logger.Formats.Log.PlainText
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
            ref LogMessageRenderData messageRenderData, Span<char> stacktrace)
        {
            RenderLogMessage(ref destination, logMessage, ref messageRenderData);
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

            if (parameterValue.SequenceEqual(LoggerConfigurationData.MessageParameterKey))
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

        private static void TryAppendStacktrace(ref ValueStringBuilder destination, Span<char> stacktrace)
        {
            if (stacktrace.IsEmpty)
            {
                return;
            }
            
            if (destination[^1] != '\n')
            {
                destination.AppendLine();
            }
                
            destination.Append(stacktrace);
        }
    }
}