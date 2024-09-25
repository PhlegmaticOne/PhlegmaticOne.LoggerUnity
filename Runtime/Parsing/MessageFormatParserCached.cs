using System.Collections;
using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Parsing.Base;

namespace OpenMyGame.LoggerUnity.Parsing
{
    internal class MessageFormatParserCached : IMessageFormatParser
    {
        private readonly IMessageFormatParser _messageFormatParser;
        private readonly Hashtable _formatsCache;

        public MessageFormatParserCached(IMessageFormatParser messageFormatParser)
        {
            _messageFormatParser = messageFormatParser;
            _formatsCache = new Hashtable();
        }
        
        public IMessageFormat Parse(string format)
        {
            if (_formatsCache.ContainsKey(format))
            {
                return (IMessageFormat)_formatsCache[format];
            }

            var messageFormat = _messageFormatParser.Parse(format);
            _formatsCache.Add(format, messageFormat);
            return messageFormat;
        }
    }
}