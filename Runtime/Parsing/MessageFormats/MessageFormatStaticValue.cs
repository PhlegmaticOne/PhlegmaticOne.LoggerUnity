using System;
using OpenMyGame.LoggerUnity.Base;

namespace OpenMyGame.LoggerUnity.Parsing.MessageFormats
{
    internal class MessageFormatStaticValue : IMessageFormat
    {
        private readonly string _value;

        public MessageFormatStaticValue(string value)
        {
            _value = value;
        }
        
        public string Render(LogMessage logMessage, Span<object> parameters)
        {
            return _value;
        }
    }
}