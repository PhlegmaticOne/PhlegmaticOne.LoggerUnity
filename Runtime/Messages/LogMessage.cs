using System;
using System.Threading;

namespace Openmygame.Logger.Messages
{
    public struct LogMessage
    {
        private static int CurrentId = -1;
        
        public LogMessage(LogLevel logLevel, string format, Exception exception = null)
        {
            Id = Interlocked.Increment(ref CurrentId);
            LogLevel = logLevel;
            Format = format;
            Exception = null;
            SetException(exception);
        }
        
        public int Id { get; }
        public LogLevel LogLevel { get; }
        public Exception Exception { get; private set; }
        public string Format { get; private set; }

        public void SetException(Exception exception)
        {
            if (exception is not null)
            {
                Exception = exception;
            }
        }
        
        public void SetFormat(string format)
        {
            if (!string.IsNullOrEmpty(format))
            {
                Format = format;
            }
        }

        public override string ToString()
        {
            return Format;
        }
    }
}