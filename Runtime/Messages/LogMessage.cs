using System;
using OpenMyGame.LoggerUnity.Messages.Tagging;

namespace OpenMyGame.LoggerUnity.Messages
{
    public partial struct LogMessage
    {
        internal LogMessage(LogLevel logLevel = LogLevel.Debug)
        {
            LogLevel = logLevel;
            Id = 0;
            Exception = null;
            Format = null;
            Tag = LogTag.Empty;
        }

        public LogMessage(int id, LogLevel logLevel)
        {
            Id = id;
            LogLevel = logLevel;
            Exception = null;
            Format = null;
            Tag = LogTag.Empty;
        }
        
        public int Id { get; }
        
        public LogLevel LogLevel { get; }
        
        public Exception Exception { get; private set; }
        
        public LogTag Tag { get; private set; }
        
        public string Format { get; private set; }
        
        public bool HasTag()
        {
            return Tag.HasValue();
        }

        public void SetTag(string tag)
        {
            if (!string.IsNullOrEmpty(tag))
            {
                Tag = new LogTag(tag);
            }
        }

        public void SetException(Exception exception)
        {
            if (exception is not null)
            {
                Exception = exception;
            }
        }
        
        public override string ToString()
        {
            return Format;
        }
    }
}