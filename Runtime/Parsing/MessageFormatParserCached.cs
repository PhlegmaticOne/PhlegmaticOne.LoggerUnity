using System.Collections;
using OpenMyGame.LoggerUnity.Runtime.Base;
using OpenMyGame.LoggerUnity.Runtime.Parsing.Base;

namespace OpenMyGame.LoggerUnity.Runtime.Parsing
{
    public class MessageFormatParserCached : IMessageFormatParser
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