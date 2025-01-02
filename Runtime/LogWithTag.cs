using System;
using Openmygame.Logger.Base;
using Openmygame.Logger.Messages;

namespace Openmygame.Logger
{
    public class LogWithTag : ILogger
    {
        private readonly string _tag;
        private readonly ILogger _logger;
        
        public LogWithTag(string tag) : this(tag, Log.Logger) { }
        
        public LogWithTag(string tag, ILogger logger)
        {
            _tag = tag;
            _logger = logger;
            IsEnabled = true;
        }

        public bool IsEnabled { get; set; }

        public LogMessage CreateMessage(LogLevel logLevel, string tag = null, Exception exception = null)
        {
            return GetLogger().CreateMessage(logLevel, _tag, exception);
        }

        public void LogMessage(LogMessage message, Span<object> parameters)
        {
            GetLogger().LogMessage(message, parameters);
        }

        private ILogger GetLogger()
        {
            return _logger switch
            {
                NullLogger => Log.Logger,
                _ => _logger
            };
        }
    }
}