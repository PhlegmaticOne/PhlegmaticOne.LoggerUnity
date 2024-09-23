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
        private readonly Dictionary<Type, IMessageFormatProperty> _formatProperties;
        private readonly IMessageFormatPropertySerializer _propertySerializer;

        public MessageFormatFactoryLogMessage(
            Dictionary<Type, IMessageFormatProperty> formatProperties,
            IMessageFormatPropertySerializer propertySerializer)
        {
            _formatProperties = formatProperties;
            _propertySerializer = propertySerializer;
        }
        
        public IMessageFormat CreateFormat(MessagePart[] messageParts)
        {
            return new MessageFormatLogMessage(messageParts, _formatProperties, _propertySerializer);
        }
    }
}