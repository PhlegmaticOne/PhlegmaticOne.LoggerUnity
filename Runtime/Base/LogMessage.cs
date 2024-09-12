using System;

namespace OpenMyGame.LoggerUnity.Runtime.Base
{
    public class LogMessage
    {
        public static LogMessage Empty => new(LogLevel.Debug, null);
        
        public LogMessage(LogLevel logLevel, IMessageFormat format, Exception exception = null)
        {
            LogLevel = logLevel;
            Format = format;
            Exception = exception;
        }
        
        public LogLevel LogLevel { get; }
        public IMessageFormat Format { get; }
        public Exception Exception { get; }

        public string Render()
        {
            return Format?.Render(this) ?? string.Empty;
        }
    }
}