using System;
using OpenMyGame.LoggerUnity.Builders;
using OpenMyGame.LoggerUnity.Configuration.Logger.Destinations.Platforms;
using OpenMyGame.LoggerUnity.Formats;
using OpenMyGame.LoggerUnity.Formats.Log;
using OpenMyGame.LoggerUnity.Formats.Message;
using OpenMyGame.LoggerUnity.Infrastructure.StringBuilders;
using OpenMyGame.LoggerUnity.Messages;
using OpenMyGame.LoggerUnity.Parsing.Models;

namespace OpenMyGame.LoggerUnity.Base
{
    public abstract class LogDestination<TConfiguration> : ILogDestination 
        where TConfiguration : LogConfiguration
    {
        private ILogFormat _logFormat;
        private IMessageFormat _messageFormat;

        internal TConfiguration Configuration { get; set; }

        public bool CanLogMessage(in LogMessage logMessage)
        {
            return logMessage.LogLevel >= Configuration.MinimumLogLevel &&
                   Configuration.Platform == LoggerPlatformProvider.GetPlatform();
        }

        public void Initialize(LoggerConfigurationParameters configurationParameters)
        {
            _logFormat = Configuration.CreateLogFormat(configurationParameters);
            _messageFormat = Configuration.CreateMessageFormat(configurationParameters);
            OnInitializing();
        }

        public virtual void LogMessage(
            in LogMessage message, MessagePart[] messageParts, Span<object> parameters, ReadOnlySpan<byte> stacktrace)
        {
            var destination = new ValueStringBuilder(stacktrace.Length);
            var messageRenderData = new LogMessageRenderData(_messageFormat, parameters, messageParts);
            _logFormat.Render(ref destination, message, ref messageRenderData, stacktrace);
            destination.Append('\0');
            LogRenderedMessage(message, ref destination);
            destination.Dispose();
        }

        protected abstract void LogRenderedMessage(in LogMessage logMessage, ref ValueStringBuilder renderedMessage);
        protected virtual void OnInitializing() { }
    }
}