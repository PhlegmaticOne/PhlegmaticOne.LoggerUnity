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

        public virtual void LogMessage(LogMessage message)
        {
            var renderedMessage = RenderMessage(message);
            LogRenderedMessage(message, renderedMessage);
        }

        public string RenderMessage(LogMessage message)
        {
            return _logFormat.Render(message);
        }

        protected abstract void LogRenderedMessage(LogMessage logMessage, string renderedMessage);
    }
}