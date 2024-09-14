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

        public string Render(in Span<object> parameters)
        {
            return Format?.Render(this, parameters) ?? string.Empty;
        }
    }
}