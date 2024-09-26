using System;
using System.Collections.Generic;
using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Parsing.Base;
using OpenMyGame.LoggerUnity.Parsing.MessageFormats;
using OpenMyGame.LoggerUnity.Parsing.Models;
using OpenMyGame.LoggerUnity.Properties.Message.Base;
using OpenMyGame.LoggerUnity.Properties.Message.Serializing;

namespace OpenMyGame.LoggerUnity.Parsing.Factories
{
    internal class MessageFormatFactoryLogMessage : IMessageFormatFactory
    {
        private readonly Dictionary<Type, IMessageFormatParameter> _messageFormatParameters;
        private readonly IMessageFormatParameterSerializer _parameterSerializer;

        public MessageFormatFactoryLogMessage(
            Dictionary<Type, IMessageFormatParameter> messageFormatParameters,
            IMessageFormatParameterSerializer parameterSerializer)
        {
            _messageFormatParameters = messageFormatParameters;
            _parameterSerializer = parameterSerializer;
        }
        
        public IMessageFormat CreateFormat(MessagePart[] messageParts)
        {
            return new MessageFormatLogMessage(messageParts, _messageFormatParameters, _parameterSerializer);
        }
    }
}