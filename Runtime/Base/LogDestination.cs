using System;
using OpenMyGame.LoggerUnity.Messages;
using OpenMyGame.LoggerUnity.Parameters.Log.Formats;
using OpenMyGame.LoggerUnity.Parameters.Message.Formats;
using OpenMyGame.LoggerUnity.Parsing.Models;

namespace OpenMyGame.LoggerUnity.Base
{
    public abstract class LogDestination<TConfiguration> : ILogDestination
        where TConfiguration : LogConfiguration
    {
        private TConfiguration _configuration;
        private ILogFormat _logFormat;
        private IMessageFormat _messageFormat;

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

        public void Initialize(LoggerConfigurationParameters configurationParameters)
        {
            _logFormat = Configuration.CreateLogFormat();
            _messageFormat = Configuration.CreateMessageFormat(configurationParameters);
            OnInitializing();
        }

        public virtual void LogMessage(LogMessage message, MessagePart[] messageParts, Span<object> parameters)
        {
            var renderedMessage = _messageFormat.Render(messageParts, parameters);
            var renderedLogMessage = _logFormat.Render(message, renderedMessage);
            LogRenderedMessage(message, renderedLogMessage, parameters);
        }

        public virtual void Dispose() { }

        protected abstract void LogRenderedMessage(LogMessage logMessage, string renderedMessage, Span<object> parameters);
        protected virtual void OnInitializing() { }

        public override string ToString() => DestinationName;
    }
}