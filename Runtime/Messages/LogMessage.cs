using System;
using OpenMyGame.LoggerUnity.Runtime.Parsing;

namespace OpenMyGame.LoggerUnity.Runtime.Messages
{
    public class LogMessage
    {
        public LogMessage(
            LogLevel logLevel, 
            MessageFormat format, 
            Exception exception = null)
        {
            LogLevel = logLevel;
            Format = format;
            Exception = exception;
        }
        
        public LogLevel LogLevel { get; }
        public MessageFormat Format { get; }
        public Exception Exception { get; }
    }
}