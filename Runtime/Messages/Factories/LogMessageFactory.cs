using System;
using System.Threading;
using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Messages.Tagging;

namespace OpenMyGame.LoggerUnity.Messages.Factories
{
    internal class LogMessageFactory : ILogMessageFactory
    {
        private readonly LogTagFormat _logTagFormat;
        
        private int _currentMessageId = -1;

        public LogMessageFactory(LogTagFormat logTagFormat)
        {
            _logTagFormat = logTagFormat;
        }

        public LogMessage CreateMessage(LogLevel logLevel, string tag, Exception exception, ILogger logger)
        {
            var messageId = Interlocked.Increment(ref _currentMessageId);
            var message = new LogMessage(messageId, logLevel, logger, _logTagFormat);
            message.SetException(exception);
            message.SetTag(tag);
            return message;
        }
    }
}