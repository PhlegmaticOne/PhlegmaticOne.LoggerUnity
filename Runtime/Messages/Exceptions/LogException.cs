using System;

namespace Openmygame.Logger.Messages.Exceptions
{
    public class LogException : Exception
    {
        public LogException(string message) : base(message) { }
        public LogException(string message, Exception innerException) : base(message, innerException) { }
    }
}