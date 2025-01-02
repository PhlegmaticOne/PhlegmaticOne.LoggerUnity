using System;
using System.Diagnostics;
using Openmygame.Logger.Base;
using Openmygame.Logger.Configuration;
using Openmygame.Logger.Infrastructure.Stacktrace;
using Openmygame.Logger.Infrastructure.StringBuilders;
using Openmygame.Logger.Messages;
using Openmygame.Logger.Messages.Tagging;
using Openmygame.Logger.Parsing.Base;
using Openmygame.Logger.Parsing.Models;
using ILogger = Openmygame.Logger.Base.ILogger;

namespace Openmygame.Logger
{
    internal class Logger : ILogger
    {
        private readonly ILogDestination[] _logDestinations;
        private readonly LogTagFormat _tagFormat;
        private readonly IMessageFormatParser _messageFormatParser;
        private readonly bool _isExtractStacktrace;

        public Logger(
            ILogDestination[] logDestinations, 
            LogTagFormat tagFormat,
            IMessageFormatParser messageFormatParser,
            bool isExtractStacktrace,
            bool isEnabled)
        {
            IsEnabled = isEnabled;
            _logDestinations = logDestinations;
            _tagFormat = tagFormat;
            _messageFormatParser = messageFormatParser;
            _isExtractStacktrace = isExtractStacktrace;
        }

        public bool IsEnabled { get; set; }

        public LogMessage CreateMessage(LogLevel logLevel, string tag = null, Exception exception = null)
        {
            return new LogMessage(this, _tagFormat, logLevel, tag, exception);
        }

        public unsafe void LogMessage(LogMessage message, Span<object> parameters)
        {
            if (!IsEnabled)
            {
                return;
            }
            
            var messageParts = _messageFormatParser.Parse(message.Format);

            if (_isExtractStacktrace)
            {
                Span<char> stacktraceBuffer = stackalloc char[LoggerConfigurationData.StacktraceBufferSize];
                var stacktrace = new StackTrace(LoggerConfigurationData.StacktraceDepth, false);
                var stringBuilder = new SpanStringBuilder(stacktraceBuffer);
                StacktraceBuilder.Build(ref stringBuilder, stacktrace);
                LogMessageToDestinations(message, messageParts, parameters, stacktraceBuffer);
            }
            else
            {
                LogMessageToDestinations(message, messageParts, parameters, Span<char>.Empty);
            }
        }

        private void LogMessageToDestinations(
            in LogMessage message, MessagePart[] messageParts, 
            Span<object> parameters, Span<char> stacktrace)
        {
            foreach (var logDestination in _logDestinations.AsSpan())
            {
                if (logDestination.CanLogMessage(message))
                {
                    logDestination.LogMessage(message, messageParts, parameters, stacktrace);
                }
            }
        }
    }
}