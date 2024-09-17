using System;
using System.Collections.Generic;
using OpenMyGame.LoggerUnity.Runtime.Base;
using OpenMyGame.LoggerUnity.Runtime.Parsing.Base;
using OpenMyGame.LoggerUnity.Runtime.Parsing.MessageFormats;
using OpenMyGame.LoggerUnity.Runtime.Parsing.Models;
using OpenMyGame.LoggerUnity.Runtime.Properties.Message.Base;
using OpenMyGame.LoggerUnity.Runtime.Properties.Message.Serializing;

namespace OpenMyGame.LoggerUnity.Runtime.Parsing.Factories
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