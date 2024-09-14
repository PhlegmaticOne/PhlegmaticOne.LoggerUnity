using System;
using OpenMyGame.LoggerUnity.Runtime.Base;

namespace OpenMyGame.LoggerUnity.Runtime.Parsing.MessageFormats
{
    internal class MessageFormatStaticValue : IMessageFormat
    {
        private readonly string _value;

        public MessageFormatStaticValue(string value)
        {
            _value = value;
        }
        
        public string Render(LogMessage logMessage, in Span<object> parameters)
        {
            return _value;
        }
    }
}