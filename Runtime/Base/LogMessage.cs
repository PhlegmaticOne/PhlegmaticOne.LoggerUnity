using System;
using OpenMyGame.LoggerUnity.Tagging;

namespace OpenMyGame.LoggerUnity.Base
{
    public partial class LogMessage
    {
        private readonly ILogger _logger;
        
        private string _format;

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

        internal string Render(in Span<object> parameters)
        {
            var messageFormat = _logger.ParseFormat(_format);
            return messageFormat.Render(this, parameters) ?? string.Empty;
        }
    }
}