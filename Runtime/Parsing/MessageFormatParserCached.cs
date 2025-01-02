using System.Collections.Concurrent;
using Openmygame.Logger.Parsing.Base;
using Openmygame.Logger.Parsing.Models;

namespace Openmygame.Logger.Parsing
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