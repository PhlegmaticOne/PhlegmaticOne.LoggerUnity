using System;
using System.Diagnostics;
using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Configuration;
using OpenMyGame.LoggerUnity.Infrastructure.Stacktrace;
using OpenMyGame.LoggerUnity.Infrastructure.StringBuilders;
using OpenMyGame.LoggerUnity.Messages;
using OpenMyGame.LoggerUnity.Messages.Factories;
using OpenMyGame.LoggerUnity.Parsing.Base;
using ILogger = OpenMyGame.LoggerUnity.Base.ILogger;

namespace OpenMyGame.LoggerUnity
{
    internal class Logger : ILogger
    {
        private readonly ILogDestination[] _logDestinations;
        private readonly IMessageFormatParser _messageFormatParser;
        private readonly ILogMessageFactory _logMessageFactory;
        private readonly bool _isExtractStacktrace;

        public Logger(
            ILogDestination[] logDestinations, 
            IMessageFormatParser messageFormatParser,
            ILogMessageFactory logMessageFactory,
            bool isExtractStacktrace)
        {
            _logDestinations = logDestinations;
            _messageFormatParser = messageFormatParser;
            _logMessageFactory = logMessageFactory;
            _isExtractStacktrace = isExtractStacktrace;
        }

        public bool IsEnabled { get; set; }

        public LogMessage CreateMessage(LogLevel logLevel, string tag = null, Exception exception = null)
        {
            return _logMessageFactory.CreateMessage(logLevel, tag, exception, this);
        }
        
        public unsafe void LogMessage(LogMessage message, Span<object> parameters)
        {
            if (!IsEnabled)
            {
                return;
            }
            
            var messageParts = _messageFormatParser.Parse(message.Format);
            var stacktrace = ReadOnlySpan<byte>.Empty;

            if (_isExtractStacktrace)
            {
                fixed (byte* stackArray = stackalloc byte[LoggerConfigurationData.StacktraceBufferSize])
                {
                    var stackTrace = new StackTrace(LoggerConfigurationData.StacktraceDepth, false);
                    var stringBuilder = new SpanStringBuilder(stackArray, LoggerConfigurationData.StacktraceBufferSize);
                    StacktraceBuilder.Build(ref stringBuilder, stackTrace);
                    stacktrace = new ReadOnlySpan<byte>(stackArray, stringBuilder.Length);
                }
            }
            
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