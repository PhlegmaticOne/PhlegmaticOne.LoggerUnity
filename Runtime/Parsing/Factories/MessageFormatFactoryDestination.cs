using System.Collections.Generic;
using System.Linq;
using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Parsing.Base;
using OpenMyGame.LoggerUnity.Parsing.MessageFormats;
using OpenMyGame.LoggerUnity.Parsing.Models;
using OpenMyGame.LoggerUnity.Properties.Log.Base;

namespace OpenMyGame.LoggerUnity.Parsing.Factories
{
    internal class MessageFormatFactoryDestination : IMessageFormatFactory
    {
        private readonly Dictionary<string, ILogFormatProperty> _logFormatProperties;

        public MessageFormatFactoryDestination(IEnumerable<ILogFormatProperty> logFormatProperties)
        {
            _logFormatProperties = logFormatProperties.ToDictionary(x => x.Key, x => x);
        }
        
        public IMessageFormat CreateFormat(MessagePart[] messageParts)
        {
            return new MessageFormatDestination(messageParts, _logFormatProperties);
        }
    }
}