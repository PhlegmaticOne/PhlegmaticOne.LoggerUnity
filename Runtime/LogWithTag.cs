using System;
using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Messages;

namespace OpenMyGame.LoggerUnity
{
    public class LogWithTag : ILogger
    {
        private readonly string _tag;
        private readonly ILogger _logger;

        public LogWithTag(string tag) : this(tag, Log.Logger)
        {
            _tag = tag;
        }

        public LogWithTag(string tag, ILogger logger)
        {
            _tag = tag;
            _logger = logger;
        }

        public bool IsEnabled { get; set; }
        
        public LogMessage CreateMessage(LogLevel logLevel, string tag = null, Exception exception = null)
        {
            return _logger.CreateMessage(logLevel, _tag, exception);
        }

        public void LogMessage(LogMessage message, Span<object> parameters)
        {
            _logger.LogMessage(message, parameters);
        }
    }
}