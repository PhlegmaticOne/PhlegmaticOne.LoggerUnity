using System;
using OpenMyGame.LoggerUnity.Formats.Log;
using OpenMyGame.LoggerUnity.Formats.Message;
using OpenMyGame.LoggerUnity.Messages;
using OpenMyGame.LoggerUnity.Parsing.Models;
using SpanUtilities.StringBuilders;

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

        public bool IsEnabled { get; set; }
        public abstract string DestinationName { get; }

        public bool CanLogMessage(in LogMessage logMessage)
        {
            return IsEnabled && logMessage.LogLevel >= _configuration.MinimumLogLevel;
        }

        public void Initialize(LoggerConfigurationParameters configurationParameters)
        {
            _logFormat = Configuration.CreateLogFormat(configurationParameters);
            _messageFormat = Configuration.CreateMessageFormat(configurationParameters);
            OnInitializing();
        }

        public virtual void LogMessage(in LogMessage message, MessagePart[] messageParts, Span<object> parameters)
        {
            var destination = ValueStringBuilder.Create();
            var messageRenderData = new LogMessageRenderData(_messageFormat, parameters, messageParts);
            _logFormat.Render(ref destination, message, ref messageRenderData);
            LogRenderedMessage(message, ref destination);
            destination.Dispose();
        }

        public virtual void Dispose() { }

        protected abstract void LogRenderedMessage(in LogMessage logMessage, ref ValueStringBuilder renderedMessage);
        protected virtual void OnInitializing() { }

        public override string ToString() => DestinationName;
    }
}