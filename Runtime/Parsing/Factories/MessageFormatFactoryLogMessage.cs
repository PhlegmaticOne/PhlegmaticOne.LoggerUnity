using System;
using System.Collections.Generic;
using OpenMyGame.LoggerUnity.Runtime.Base;
using OpenMyGame.LoggerUnity.Runtime.Parsing.Base;
using OpenMyGame.LoggerUnity.Runtime.Parsing.MessageFormats;
using OpenMyGame.LoggerUnity.Runtime.Parsing.Models;
using OpenMyGame.LoggerUnity.Runtime.Properties.Message.Base;

namespace OpenMyGame.LoggerUnity.Runtime.Parsing.Factories
{
    public class MessageFormatFactoryLogMessage : IMessageFormatFactory
    {
        private readonly Dictionary<Type, IMessageFormatProperty> _formatProperties;

        public MessageFormatFactoryLogMessage(Dictionary<Type, IMessageFormatProperty> formatProperties)
        {
            _formatProperties = formatProperties;
        }
        
        public IMessageFormat CreateFormat(MessagePart[] messageParts)
        {
            return new MessageFormatLogMessage(messageParts, _formatProperties);
        }
    }
}