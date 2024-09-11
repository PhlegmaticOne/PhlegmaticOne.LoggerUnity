using System;
using OpenMyGame.LoggerUnity.Runtime.Parsing;

namespace OpenMyGame.LoggerUnity.Runtime.Messages
{
    public class LogMessage
    {
        public static LogMessage Empty => new(LogLevel.Debug, null);
        
        public LogMessage(LogLevel logLevel, MessageFormat format, Exception exception = null)
        {
            LogLevel = logLevel;
            Format = format;
            Exception = exception;
        }
        
        public LogLevel LogLevel { get; }
        public MessageFormat Format { get; }
        public Exception Exception { get; }

        public string Render()
        {
            return Format?.Render(this) ?? string.Empty;
        }
    }
}