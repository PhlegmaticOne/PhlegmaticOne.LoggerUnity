using System.Collections.Generic;
using System.Linq;
using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Parameters.Log.Base;
using OpenMyGame.LoggerUnity.Parsing.Base;
using OpenMyGame.LoggerUnity.Parsing.MessageFormats;
using OpenMyGame.LoggerUnity.Parsing.Models;

namespace OpenMyGame.LoggerUnity.Parsing.Factories
{
    internal class MessageFormatFactoryDestination : IMessageFormatFactory
    {
        private readonly Dictionary<string, ILogFormatParameter> _logFormatParameters;

        public MessageFormatFactoryDestination(IEnumerable<ILogFormatParameter> logFormatParameters)
        {
            _logFormatParameters = logFormatParameters.ToDictionary(x => x.Key, x => x);
        }
        
        public IMessageFormat CreateFormat(MessagePart[] messageParts)
        {
            return new MessageFormatDestination(messageParts, _logFormatParameters);
        }
    }
}