using System;
using System.Collections.Generic;
using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Parameters.Message.Base;
using OpenMyGame.LoggerUnity.Parameters.Message.Processors;
using OpenMyGame.LoggerUnity.Parameters.Message.Serializing;
using OpenMyGame.LoggerUnity.Parsing.Models;
using SpanUtilities.StringBuilders;

namespace OpenMyGame.LoggerUnity.Formats.Message
{
    internal class MessageFormat : IMessageFormat
    {
        private readonly Dictionary<Type, IMessageFormatParameter> _messageFormatParameters;
        private readonly IMessageFormatParameterSerializer _parameterSerializer;
        private readonly IMessageParameterPostRenderer _postRenderer;

        public MessageFormat(
            Dictionary<Type, IMessageFormatParameter> messageFormatParameters,
            IMessageFormatParameterSerializer parameterSerializer,
            IMessageParameterPostRenderer postRenderer)
        {
            _messageFormatParameters = messageFormatParameters;
            _parameterSerializer = parameterSerializer;
            _postRenderer = postRenderer;
        }

        public ValueStringBuilder Render(MessagePart[] messageParts, Span<object> parameters)
        {
            if (messageParts.Length == 0)
            {
                return string.Empty;
            }
            
            var destination = ValueStringBuilder.Create();
            var currentParameterIndex = -1;

            foreach (var messagePart in messageParts.AsSpan())
            {
                Render(messagePart, parameters, ref destination, ref currentParameterIndex);
            }
            
            return destination;
        }

        private void Render(
            in MessagePart messagePart, in Span<object> parameters, ref ValueStringBuilder destination, ref int currentParameterIndex)
        {
            messagePart.SplitParameterToValueAndFormat(out var parameterValue, out var format);

            if (parameterValue.IsEmpty)
            {
                return;
            }
            
            if (!messagePart.IsParameter || parameters.Length == 0)
            {
                destination.Append(parameterValue);
                return;
            }

            var parameter = GetCurrentParameter(in parameters, ref currentParameterIndex);

            _postRenderer.Preprocess(ref destination, parameter);

            if (parameterValue[0] == LoggerStaticData.SerializeParameterPrefix)
            {
                destination.Append(_parameterSerializer.Serialize(parameter, format));
            }
            else
            {
                if (_messageFormatParameters.TryGetValue(parameter.GetType(), out var property))
                {
                    property.Render(ref destination, parameter, format);
                }
                else
                {
                    destination.Append(parameter.ToString());
                }
            }
            
            _postRenderer.Postprocess(ref destination, parameter);
        }

        private static object GetCurrentParameter(in Span<object> parameters, ref int currentParameterIndex)
        {
            currentParameterIndex = (currentParameterIndex + 1) % parameters.Length;
            return parameters[currentParameterIndex];
        }
    }
}