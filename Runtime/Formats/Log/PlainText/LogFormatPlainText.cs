using System;
using System.Collections.Generic;
using OpenMyGame.LoggerUnity.Infrastructure.Pools.PoolableTypes;
using OpenMyGame.LoggerUnity.Infrastructure.Pools.Providers;
using OpenMyGame.LoggerUnity.Messages;
using OpenMyGame.LoggerUnity.Parameters.Log.Base;
using OpenMyGame.LoggerUnity.Parameters.Log.Processors;
using OpenMyGame.LoggerUnity.Parsing.Models;

namespace OpenMyGame.LoggerUnity.Formats.Log.PlainText
{
    internal class LogFormatPlainText : ILogFormat
    {
        private readonly bool _appendStacktraceToRenderingMessage;
        private readonly MessagePart[] _messageParts;
        private readonly Dictionary<string, ILogFormatParameter> _logFormatParameters;
        private readonly ILogParameterPostRenderer _postRenderer;
        private readonly IPoolProvider _poolProvider;

        public LogFormatPlainText(
            MessagePart[] messageParts,
            bool appendStacktraceToRenderingMessage, 
            Dictionary<string, ILogFormatParameter> logFormatParameters,
            ILogParameterPostRenderer postRenderer,
            IPoolProvider poolProvider)
        {
            _appendStacktraceToRenderingMessage = appendStacktraceToRenderingMessage;
            _messageParts = messageParts;
            _logFormatParameters = logFormatParameters;
            _postRenderer = postRenderer;
            _poolProvider = poolProvider;
        }
        
        public string Render(in LogMessage logMessage, string renderedMessage, MessagePart[] messageParts, in Span<object> parameters)
        {
            var destination = _poolProvider.Get<StringBuilderPoolable>();
            RenderLogMessage(logMessage, renderedMessage, destination);
            TryAppendStacktrace(destination, logMessage);
            var result = destination.ToStringResult();
            _poolProvider.Return(destination);
            return result;
        }

        private void RenderLogMessage(in LogMessage logMessage, string renderedMessage, StringBuilderPoolable logBuilder)
        {
            foreach (var messagePart in _messageParts)
            {
                var renderMessagePart = Render(messagePart, logMessage, renderedMessage);

                if (messagePart.IsParameter)
                {
                    _postRenderer.Process(logBuilder.Value, messagePart, renderMessagePart);
                }
                else
                {
                    logBuilder.Value.Append(renderMessagePart);
                }
            }
        }

        private void TryAppendStacktrace(StringBuilderPoolable destination, in LogMessage logMessage)
        {
            if (_appendStacktraceToRenderingMessage && 
                logMessage.Stacktrace.TryGetUserCodeStacktrace(out var userCodeStacktrace))
            {
                if (destination.Value[^1] != '\n')
                {
                    destination.Value.AppendLine();
                }
                
                destination.Value.Append(userCodeStacktrace);
            }
        }

        private ReadOnlySpan<char> Render(in MessagePart messagePart, in LogMessage message, string renderedMessage)
        {
            messagePart.SplitParameterToValueAndFormat(out var parameterValue, out _);
            var property = _logFormatParameters.GetValueOrDefault(parameterValue.ToString());
            return property is null ? parameterValue : property.GetValue(messagePart, message, renderedMessage);
        }
    }
}