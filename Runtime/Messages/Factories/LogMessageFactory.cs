using System;
using System.Threading;

namespace OpenMyGame.LoggerUnity.Messages.Factories
{
    internal class LogMessageFactory : ILogMessageFactory
    {
        private int _currentMessageId = -1;
        
        public LogMessage CreateMessage(LogLevel logLevel, string tag, Exception exception)
        {
            var messageId = Interlocked.Increment(ref _currentMessageId);
            var message = new LogMessage(messageId, logLevel);
            message.SetException(exception);
            message.SetTag(tag);
            return message;
        }
    }
}