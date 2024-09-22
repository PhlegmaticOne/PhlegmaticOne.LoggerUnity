using System;
using OpenMyGame.LoggerUnity.Runtime.Tagging;

namespace OpenMyGame.LoggerUnity.Runtime.Base
{
    public class LogMessage
    {
        public LogMessage(LogLevel logLevel, IMessageFormat format, Exception exception = null)
        {
            LogLevel = logLevel;
            Format = format;
            Exception = exception;
        }
        
        public LogLevel LogLevel { get; }
        public IMessageFormat Format { get; }
        public Exception Exception { get; }
        public LogTag Tag { get; private set; }

        public string Render(in Span<object> parameters)
        {
            return Format?.Render(this, parameters) ?? string.Empty;
        }

        public void SetTag(in LogTag logTag)
        {
            Tag = logTag;
        }
    }
}