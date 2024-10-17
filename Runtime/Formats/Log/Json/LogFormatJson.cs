using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using OpenMyGame.LoggerUnity.Infrastructure.Pools.PoolableTypes;
using OpenMyGame.LoggerUnity.Infrastructure.Pools.Providers;
using OpenMyGame.LoggerUnity.Messages;
using OpenMyGame.LoggerUnity.Messages.Exceptions;
using OpenMyGame.LoggerUnity.Parameters.Log.Base;
using OpenMyGame.LoggerUnity.Parameters.Log.Processors;
using OpenMyGame.LoggerUnity.Parsing.Models;

namespace OpenMyGame.LoggerUnity.Formats.Log.Json
{
    internal class LogFormatJson : ILogFormat
    {
        private const string ParametersKey = "Parameters";
        private const string StacktraceKey = "Stacktrace";
        
        private readonly MessagePart[] _messageParts;
        private readonly bool _appendStacktraceToRenderingMessage;
        private readonly ILogParameterPostRenderer _logParameterPostRenderer;
        private readonly IPoolProvider _poolProvider;
        private readonly Dictionary<string, ILogFormatParameter> _logFormatParameters;

        public LogFormatJson(
            MessagePart[] messageParts, 
            bool appendStacktraceToRenderingMessage, 
            ILogParameterPostRenderer logParameterPostRenderer,
            IPoolProvider poolProvider,
            Dictionary<string, ILogFormatParameter> logFormatParameters)
        {
            _appendStacktraceToRenderingMessage = appendStacktraceToRenderingMessage;
            _logParameterPostRenderer = logParameterPostRenderer;
            _poolProvider = poolProvider;
            _messageParts = messageParts;
            _logFormatParameters = logFormatParameters;
        }
        
        public string Render(in LogMessage logMessage, string renderedMessage, MessagePart[] messageParts, in Span<object> parameters)
        {
            var resultObject = new JObject();
            RenderLogMessage(logMessage, renderedMessage, resultObject);
            RenderParameters(messageParts, parameters, resultObject);
            RenderStacktrace(logMessage, resultObject);
            return resultObject.ToString();
        }
        
        private void RenderLogMessage(in LogMessage logMessage, string renderedMessage, JObject resultObject)
        {
            var destination = _poolProvider.Get<StringBuilderPoolable>();
            
            foreach (var messagePart in _messageParts)
            {
                if (!messagePart.TryGetParameter(out var parameterSpan))
                {
                    continue;
                }

                var parameterKey = parameterSpan.ToString();
                var parameter = _logFormatParameters.GetValueOrDefault(parameterKey);

                if (parameter is not null)
                {
                    var renderedValue = parameter.GetValue(messagePart, logMessage, renderedMessage);
                    _logParameterPostRenderer.Process(destination.Value, messagePart, renderedValue);
                    resultObject[parameterKey] = destination.ToStringResult();
                    destination.Clear();
                }
            }
            
            _poolProvider.Return(destination);
        }

        private void RenderStacktrace(in LogMessage logMessage, JObject resultObject)
        {
            if (_appendStacktraceToRenderingMessage && 
                logMessage.Stacktrace.TryGetUserCodeStacktrace(out var userCodeStacktrace))
            {
                resultObject[StacktraceKey] = userCodeStacktrace.ToString();
            }
        }

        private static void RenderParameters(MessagePart[] messageParts, in Span<object> parameters, JObject resultObject)
        {
            var i = 0;
            var parametersObject = new JObject();

            foreach (var messagePart in messageParts)
            {
                if (!messagePart.TryGetParameter(out var parameterSpan) || 
                    !IsAllowedParameterForJsonProperty(parameters[i]))
                {
                    continue;
                }

                var parameterKey = parameterSpan.ToString();
                var parameterValue = parameters[i];
                parametersObject.Add(parameterKey, JToken.FromObject(parameterValue));
                i++;
            }
            
            resultObject[ParametersKey] = parametersObject;
        }

        private static bool IsAllowedParameterForJsonProperty(object parameter)
        {
            return parameter is not LogExceptionPlaceholder;
        }
    }
}