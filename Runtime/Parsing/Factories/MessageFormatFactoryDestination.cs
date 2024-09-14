using System.Collections.Generic;
using System.Linq;
using OpenMyGame.LoggerUnity.Runtime.Base;
using OpenMyGame.LoggerUnity.Runtime.Parsing.Base;
using OpenMyGame.LoggerUnity.Runtime.Parsing.MessageFormats;
using OpenMyGame.LoggerUnity.Runtime.Parsing.Models;
using OpenMyGame.LoggerUnity.Runtime.Properties.Log.Base;

namespace OpenMyGame.LoggerUnity.Runtime.Parsing.Factories
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