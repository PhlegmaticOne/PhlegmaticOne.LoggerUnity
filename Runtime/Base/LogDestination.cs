using System;
using Openmygame.Logger.Builders;
using Openmygame.Logger.Configuration.Logger.Destinations.Platforms;
using Openmygame.Logger.Formats;
using Openmygame.Logger.Formats.Log;
using Openmygame.Logger.Formats.Message;
using Openmygame.Logger.Infrastructure.StringBuilders;
using Openmygame.Logger.Messages;
using Openmygame.Logger.Messages.Tagging;
using Openmygame.Logger.Parsing.Models;

namespace Openmygame.Logger.Base
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
                   LoggerPlatformProvider.HasPlatform(Configuration.Platform);
        }

        public void Initialize(LoggerConfigurationParameters configurationParameters)
        {
            _logFormat = Configuration.CreateLogFormat(configurationParameters);
            _messageFormat = Configuration.CreateMessageFormat(configurationParameters);
            OnInitializing();
        }

        public void LogMessage(
            in LogMessage message, MessagePart[] messageParts, Span<object> parameters, Span<char> stacktrace)
        {
            var destination = new ValueStringBuilder(stacktrace.Length);
            var messageRenderData = new LogMessageRenderData(_messageFormat, parameters, messageParts);
            _logFormat.Render(ref destination, message, ref messageRenderData, stacktrace);
            destination.Append('\0');
            LogRenderedMessage(message, FindTagInParameters(parameters), ref destination);
            destination.Dispose();
        }

        protected abstract void LogRenderedMessage(in LogMessage logMessage, Tag tag, ref ValueStringBuilder renderedMessage);
        protected virtual void OnInitializing() { }

        private static Tag FindTagInParameters(Span<object> parameters)
        {
            foreach (var parameter in parameters)
            {
                if (parameter is Tag { IsSubsystem: false } tag)
                {
                    return tag;
                }
            }
            
            return Tag.Empty;
        }
    }
}