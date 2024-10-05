using System;
using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Tagging;

namespace OpenMyGame.LoggerUnity.Messages
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

        public LogMessage(LogLevel logLevel, LogStacktrace stacktrace, ILogger logger)
        {
            LogLevel = logLevel;
            Stacktrace = stacktrace;
            _logger = logger;
        }
        
        public LogLevel LogLevel { get; }
        public LogStacktrace Stacktrace { get; }
        public Exception Exception { get; private set; }
        public LogTag Tag { get; private set; }
        public string Format { get; private set; }

        public bool HasTag()
        {
            return Tag is not null;
        }

        public bool HasStacktrace()
        {
            return Stacktrace.HasValue();
        }

        public LogMessage WithTag(string tag)
        {
            if (!string.IsNullOrEmpty(tag))
            {
                Tag = LogTag.TagOnly(tag);
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