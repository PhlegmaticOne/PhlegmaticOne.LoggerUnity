using System;
using System.Collections.Generic;
using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Extensions;
using OpenMyGame.LoggerUnity.Infrastructure.Pools.PoolableTypes;
using OpenMyGame.LoggerUnity.Infrastructure.Pools.Providers;
using OpenMyGame.LoggerUnity.Parameters.Message.Base;
using OpenMyGame.LoggerUnity.Parameters.Message.Processors;
using OpenMyGame.LoggerUnity.Parameters.Message.Serializing;
using OpenMyGame.LoggerUnity.Parsing.Models;

namespace OpenMyGame.LoggerUnity.Formats.Message
{
    internal class MessageFormat : IMessageFormat
    {
        private readonly Dictionary<Type, IMessageFormatParameter> _messageFormatParameters;
        private readonly IMessageFormatParameterSerializer _parameterSerializer;
        private readonly IMessageParameterPostRenderer _postRenderer;
        private readonly IPoolProvider _poolProvider;

        public MessageFormat(
            Dictionary<Type, IMessageFormatParameter> messageFormatParameters,
            IMessageFormatParameterSerializer parameterSerializer,
            IMessageParameterPostRenderer postRenderer,
            IPoolProvider poolProvider)
        {
            _messageFormatParameters = messageFormatParameters;
            _parameterSerializer = parameterSerializer;
            _postRenderer = postRenderer;
            _poolProvider = poolProvider;
        }

        public string Render(MessagePart[] messageParts, Span<object> parameters)
        {
            if (messageParts.Length == 0)
            {
                return string.Empty;
            }
            
            var destination = _poolProvider.Get<StringBuilderPoolable>();
            var currentParameterIndex = -1;

            foreach (var messagePart in messageParts)
            {
                var renderMessagePart = Render(messagePart, parameters, ref currentParameterIndex);

                if (!messagePart.IsParameter)
                {
                    destination.Value.Append(renderMessagePart);
                }
                else if(parameters.IndexWithinRange(currentParameterIndex))
                {
                    _postRenderer.Process(destination.Value, renderMessagePart, parameters[currentParameterIndex]);   
                }
            }

            var result = destination.ToStringResult();
            _poolProvider.Return(destination);
            return result;
        }

        private ReadOnlySpan<char> Render(in MessagePart messagePart, in Span<object> parameters, ref int currentParameterIndex)
        {
            messagePart.SplitParameterToValueAndFormat(out var parameterValue, out var format);
            
            if (!messagePart.IsParameter || parameters.Length == 0)
            {
                return parameterValue;
            }

            var parameter = GetCurrentParameter(in parameters, ref currentParameterIndex);
            return RenderParameter(parameter, parameterValue, format);
        }

        private ReadOnlySpan<char> RenderParameter(
            object parameter, in ReadOnlySpan<char> parameterValue, in ReadOnlySpan<char> format)
        {
            var type = parameter.GetType();

            if (parameterValue[0] == LoggerStaticData.SerializeParameterPrefix)
            {
                return _parameterSerializer.Serialize(parameter, format);
            }
            
            if (_messageFormatParameters.TryGetValue(type, out var property))
            {
                return property.Render(parameter, format);
            }
            
            return parameter.ToString();
        }

        private static object GetCurrentParameter(in Span<object> parameters, ref int currentParameterIndex)
        {
            currentParameterIndex = (currentParameterIndex + 1) % parameters.Length;
            return parameters[currentParameterIndex];
        }
    }
}