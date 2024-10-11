using System;

namespace OpenMyGame.LoggerUnity.Messages.Exceptions
{
    /// <summary>
    /// Исключение для оборачивания логгируемых исключений
    /// </summary>
    public class LogException : Exception
    {
        public LogException(string message) : base(message) { }
        public LogException(string message, Exception innerException) : base(message, innerException) { }
    }
}