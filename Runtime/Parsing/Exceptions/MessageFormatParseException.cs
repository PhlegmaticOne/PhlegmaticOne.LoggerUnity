using System;

namespace OpenMyGame.LoggerUnity.Parsing.Exceptions
{
    /// <summary>
    /// Исключение для ошибок, связанных с парсингом форматов сообщений
    /// </summary>
    public class MessageFormatParseException : Exception
    {
        public MessageFormatParseException(string message) : base(message) { }
    }
}