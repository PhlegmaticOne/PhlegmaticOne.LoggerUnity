using System;

namespace Openmygame.Logger.Parsing.Exceptions
{
    public class MessageFormatParseException : Exception
    {
        public MessageFormatParseException(string message) : base(message) { }
    }
}