using System.Collections.Concurrent;
using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Parsing.Base;

namespace OpenMyGame.LoggerUnity.Parsing
{
    internal class MessageFormatParserCached : IMessageFormatParser
    {
        private readonly IMessageFormatParser _messageFormatParser;
        private readonly ConcurrentDictionary<string, IMessageFormat> _formatsCache;

        public MessageFormatParserCached(IMessageFormatParser messageFormatParser)
        {
            _messageFormatParser = messageFormatParser;
            _formatsCache = new ConcurrentDictionary<string, IMessageFormat>();
        }
        
        public IMessageFormat Parse(string format)
        {
            return _formatsCache.GetOrAdd(format, f => _messageFormatParser.Parse(f));
        }
    }
}