using System;

namespace OpenMyGame.LoggerUnity.Runtime.Parsing.Exceptions
{
    public class MessageFormatParseException : Exception
    {
        public MessageFormatParseException(string message) : base(message) { }
    }
}