using System;
using System.Threading;
using OpenMyGame.LoggerUnity.Base;

namespace OpenMyGame.LoggerUnity.Messages.Factories
{
    internal class LogMessageFactory : ILogMessageFactory
    {
        private int _currentMessageId = -1;

        public LogMessage CreateMessage(LogLevel logLevel, string tag, Exception exception, ILogger logger)
        {
            var messageId = Interlocked.Increment(ref _currentMessageId);
            var message = new LogMessage(messageId, logLevel, logger);
            message.SetException(exception);
            message.SetTag(tag);
            return message;
        }
    }
}