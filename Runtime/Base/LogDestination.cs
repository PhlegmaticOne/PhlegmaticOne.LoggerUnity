using System;

namespace OpenMyGame.LoggerUnity.Runtime.Base
{
    public abstract class LogDestination<TConfiguration> : ILogDestination
        where TConfiguration : LogConfiguration
    {
        private TConfiguration _configuration;
        private IMessageFormat _logFormat;

        internal TConfiguration Configuration
        {
            get => _configuration;
            set
            {
                _configuration = value;
                IsEnabled = _configuration.IsEnabled;
            }
        }

        public abstract string DestinationName { get; }
        public LogConfiguration Config => Configuration;
        public bool IsEnabled { get; set; }

        public virtual void Initialize()
        {
            _logFormat = Configuration.CreateMessageFormat();
        }

        public virtual void LogMessage(LogMessage message, in Span<object> parameters)
        {
            var renderedMessage = _logFormat.Render(message, parameters);
            LogRenderedMessage(message, renderedMessage);
        }

        public virtual void Release() { }

        protected abstract void LogRenderedMessage(LogMessage logMessage, string renderedMessage);
    }
}