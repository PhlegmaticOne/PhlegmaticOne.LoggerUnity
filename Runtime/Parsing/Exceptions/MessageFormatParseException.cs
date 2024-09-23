using System;

namespace OpenMyGame.LoggerUnity.Parsing.Exceptions
{
    public class MessageFormatParseException : Exception
    {
        public MessageFormatParseException(string message) : base(message) { }
    }
}