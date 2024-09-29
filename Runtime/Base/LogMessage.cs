using System;
using OpenMyGame.LoggerUnity.Tagging;

namespace OpenMyGame.LoggerUnity.Base
{
    public partial class LogMessage
    {
        private readonly ILogger _logger;

        internal LogMessage(LogLevel logLevel)
        {
            LogLevel = logLevel;
        }

        internal LogMessage(Exception exception)
        {
            Exception = exception;
        }

        public LogMessage(LogLevel logLevel, ILogger logger)
        {
            LogLevel = logLevel;
            _logger = logger;
        }
        
        public LogLevel LogLevel { get; }
        public Exception Exception { get; private set; }
        public LogTag Tag { get; private set; }
        internal string RenderedMessage { get; private set; }

        public LogMessage WithTag(string tag)
        {
            if (!string.IsNullOrEmpty(tag))
            {
                Tag = _logger.LogTagProvider.CreateTag(tag);
            }

            return this;
        }

        public LogMessage WithException(Exception exception)
        {
            if (exception is not null)
            {
                Exception = exception;
            }

            return this;
        }
    }
}