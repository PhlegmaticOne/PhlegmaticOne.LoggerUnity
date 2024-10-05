using System;
using System.Collections.Generic;
using System.Text;
using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Parameters.Log.Base;
using OpenMyGame.LoggerUnity.Parameters.Log.Processors;
using OpenMyGame.LoggerUnity.Parsing.Models;

namespace OpenMyGame.LoggerUnity.Parameters.Log.Formats
{
    public class LogFormat : ILogFormat
    {
        private readonly MessagePart[] _messageParts;
        private readonly Dictionary<string, ILogFormatParameter> _logFormatParameters;
        private readonly ILogParameterPostRenderProcessor _postRenderProcessor;

        public LogFormat(
            MessagePart[] messageParts, 
            Dictionary<string, ILogFormatParameter> logFormatParameters,
            ILogParameterPostRenderProcessor postRenderProcessor)
        {
            _messageParts = messageParts;
            _logFormatParameters = logFormatParameters;
            _postRenderProcessor = postRenderProcessor;
        }
        
        public string Render(LogMessage logMessage, string renderedMessage)
        {
            var logBuilder = new StringBuilder();

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
            
            return logBuilder.ToString();
        }
        
        private ReadOnlySpan<char> Render(MessagePart messagePart, LogMessage message, string renderedMessage)
        {
            messagePart.SplitParameterToValueAndFormat(out var parameterValue, out _);
            var property = _logFormatParameters.GetValueOrDefault(parameterValue.ToString());
            return property is null ? parameterValue : property.GetValue(messagePart, message, renderedMessage);
        }
    }
}