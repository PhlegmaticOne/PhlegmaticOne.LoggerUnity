using System.Collections.Concurrent;
using OpenMyGame.LoggerUnity.Parsing.Base;
using OpenMyGame.LoggerUnity.Parsing.Models;

namespace OpenMyGame.LoggerUnity.Parsing
{
    internal class MessageFormatParserCached : IMessageFormatParser
    {
        private readonly IMessageFormatParser _messageFormatParser;
        private readonly ConcurrentDictionary<string, MessagePart[]> _formatsCache;

        public MessageFormatParserCached(IMessageFormatParser messageFormatParser)
        {
            _messageFormatParser = messageFormatParser;
            _formatsCache = new ConcurrentDictionary<string, MessagePart[]>();
        }
        
        public MessagePart[] Parse(string format)
        {
            return _formatsCache.GetOrAdd(format, f => _messageFormatParser.Parse(f));
        }
    }
}