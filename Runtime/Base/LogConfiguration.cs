using System.Collections.Generic;
using OpenMyGame.LoggerUnity.Runtime.Messages;

namespace OpenMyGame.LoggerUnity.Runtime.Base
{
    public abstract class LogConfiguration
    {
        private readonly List<ILogMessageEnricher> _enrichers = new();

        protected LogConfiguration()
        {
            MinimumLogLevel = LogLevel.Debug;
            LogFormat = "{Message}";
            IsEnabled = false;
        }
        
        public IReadOnlyList<ILogMessageEnricher> MessageEnrichers => _enrichers;
        public LogLevel MinimumLogLevel { get; set; }
        public LogLevel MinimumStacktraceLevel { get; set; } = LogLevel.Debug;
        public string LogFormat { get; set; }
        public bool IsEnabled { get; set; }
        
        
        public LogConfiguration AddEnricher(ILogMessageEnricher messageEnricher)
        {
            _enrichers.Add(messageEnricher);
            return this;
        }
    }
}