using System;
using System.Collections.Generic;
using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Parameters.Message.Base;
using OpenMyGame.LoggerUnity.Parameters.Message.Serializing;
using OpenMyGame.LoggerUnity.Parameters.Processors;
using OpenMyGame.LoggerUnity.Parsing.Base;
using OpenMyGame.LoggerUnity.Parsing.MessageFormats;
using OpenMyGame.LoggerUnity.Parsing.Models;

namespace OpenMyGame.LoggerUnity.Parsing.Factories
{
    internal class MessageFormatFactoryLogMessage : IMessageFormatFactory
    {
        private readonly Dictionary<Type, IMessageFormatParameter> _messageFormatParameters;
        private readonly IMessageFormatParameterSerializer _parameterSerializer;
        private readonly IParameterPostRenderProcessor _postRenderProcessor;

        public MessageFormatFactoryLogMessage(
            Dictionary<Type, IMessageFormatParameter> messageFormatParameters,
            IMessageFormatParameterSerializer parameterSerializer,
            IParameterPostRenderProcessor postRenderProcessor)
        {
            _messageFormatParameters = messageFormatParameters;
            _parameterSerializer = parameterSerializer;
            _postRenderProcessor = postRenderProcessor;
        }
        
        public IMessageFormat CreateFormat(MessagePart[] messageParts)
        {
            return new MessageFormatLogMessage(messageParts, 
                _messageFormatParameters, _parameterSerializer, _postRenderProcessor);
        }
    }
}