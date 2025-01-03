﻿using System;
using System.Collections.Generic;
using Openmygame.Logger.Configuration;
using Openmygame.Logger.Infrastructure.Extensions;
using Openmygame.Logger.Infrastructure.StringBuilders;
using Openmygame.Logger.Parameters.Message.Base;
using Openmygame.Logger.Parameters.Message.Processors;
using Openmygame.Logger.Parameters.Message.Serializing;
using Openmygame.Logger.Parsing.Models;

namespace Openmygame.Logger.Formats.Message
{
    internal class MessageFormat : IMessageFormat
    {
        private readonly Dictionary<Type, IMessageFormatParameter> _messageFormatParameters;
        private readonly IMessageFormatParameterSerializer _parameterSerializer;
        private readonly IMessageParameterProcessor _processor;

        public MessageFormat(
            Dictionary<Type, IMessageFormatParameter> messageFormatParameters,
            IMessageFormatParameterSerializer parameterSerializer,
            IMessageParameterProcessor processor)
        {
            _messageFormatParameters = messageFormatParameters;
            _parameterSerializer = parameterSerializer;
            _processor = processor;
        }

        public void Render(ref ValueStringBuilder destination, MessagePart[] messageParts, Span<object> parameters)
        {
            if (messageParts.Length == 0)
            {
                return;
            }
            
            var currentParameterIndex = -1;

            foreach (var messagePart in messageParts.AsSpan())
            {
                Render(messagePart, parameters, ref destination, ref currentParameterIndex);
            }
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

            _processor.Preprocess(ref destination, parameter);

            if (parameterValue[0] == LoggerConfigurationData.SerializeParameterPrefix)
            {
                destination.Append(_parameterSerializer.Serialize(parameter, format));
            }
            else
            {
                var type = parameter.GetType();

                if (type.IsEnum)
                {
                    destination.Append(((Enum)parameter).ToStringCache());
                    return;
                }
                
                if (_messageFormatParameters.TryGetValue(type, out var property))
                {
                    property.Render(ref destination, parameter, format);
                }
                else
                {
                    destination.Append(parameter.ToString());
                }
            }
            
            _processor.Postprocess(ref destination, parameter);
        }

        private static object GetCurrentParameter(in Span<object> parameters, ref int currentParameterIndex)
        {
            currentParameterIndex = (currentParameterIndex + 1) % parameters.Length;
            return parameters[currentParameterIndex];
        }
    }
}