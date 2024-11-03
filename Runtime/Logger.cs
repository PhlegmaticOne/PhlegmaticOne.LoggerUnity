using System;
using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Extensions;
using OpenMyGame.LoggerUnity.Messages;
using OpenMyGame.LoggerUnity.Messages.Factories;
using OpenMyGame.LoggerUnity.Parsing.Base;
using UnityEngine;
using Debug = UnityEngine.Debug;
using ILogger = OpenMyGame.LoggerUnity.Base.ILogger;
#if !UNITY_EDITOR
using System.Diagnostics;
using OpenMyGame.LoggerUnity.Infrastructure.Stacktrace;
using OpenMyGame.LoggerUnity.Infrastructure.StringBuilders;
#endif

namespace OpenMyGame.LoggerUnity
{
    /// <summary>
    /// Стандартная реализация логгера
    /// </summary>
    internal class Logger : ILogger
    {
        private readonly ILogDestination[] _logDestinations;
        private readonly IMessageFormatParser _messageFormatParser;
        private readonly LoggerConfigurationParameters _configurationParameters;
        private readonly ILogMessageFactory _messageFactory;
        private readonly bool _isExtractStacktrace;

        private bool _isEnabled;
        private bool _isDisposed;

        public Logger(
            ILogDestination[] logDestinations,
            IMessageFormatParser messageFormatParser,
            LoggerConfigurationParameters configurationParameters,
            ILogMessageFactory messageFactory,
            bool isExtractStacktrace)
        {
            _logDestinations = logDestinations;
            _messageFormatParser = messageFormatParser;
            _configurationParameters = configurationParameters;
            _messageFactory = messageFactory;
            _isExtractStacktrace = isExtractStacktrace;
            _isDisposed = true;
        }

        public bool IsEnabled
        {
            get => _isEnabled;
            set
            {
                _isEnabled = value;
                HandleLoggerEnabledUpdated();
            }
        }

        public void Initialize()
        {
            if (!IsEnabled)
            {
                return;
            }

            foreach (var loggerDestination in _logDestinations.AsSpan())
            {
                loggerDestination.Initialize(_configurationParameters);
            }

            _isDisposed = false;
        }

        public LogMessage CreateMessage(LogLevel logLevel, int stacktraceDepth)
        {
            return _messageFactory.CreateMessage(logLevel, stacktraceDepth);
        }

        public unsafe void LogMessage(LogMessage logMessage, Span<object> parameters)
        {
            if (!IsEnabled)
            {
                return;
            }

            var messageParts = _messageFormatParser.Parse(logMessage.Format);
            var stacktrace = ReadOnlySpan<byte>.Empty;

            #region Stacktrace
            
            if (_isExtractStacktrace)
            {
                var depth = LoggerStaticData.StacktraceDepth + logMessage.StacktraceDepth;
                
                fixed (byte* stackArray = stackalloc byte[LoggerStaticData.StacktraceBufferSize])
                {
#if UNITY_EDITOR
                    var actualExtracted = Debug
                        .ExtractStackTraceNoAlloc(stackArray, LoggerStaticData.StacktraceBufferSize, Application.dataPath);

                    var temp = new Span<byte>(stackArray, actualExtracted);
                    var userCodeStartPosition = temp.GetPositionAfterByte(LoggerStaticData.NewLineByte, depth);
                
                    stacktrace = new ReadOnlySpan<byte>(
                        stackArray + userCodeStartPosition, actualExtracted - userCodeStartPosition);   
#else
                    var stackTrace = new StackTrace(depth, true);
                    var stringBuilder = new SpanStringBuilder(stackArray, LoggerStaticData.StacktraceBufferSize);
                    StacktraceBuilder.Build(ref stringBuilder, stackTrace);
                    stacktrace = new ReadOnlySpan<byte>(stackArray, stringBuilder.Length);
#endif
                }
            }
            
            #endregion
            
            foreach (var logDestination in _logDestinations.AsSpan())
            {
                if (logDestination.CanLogMessage(logMessage))
                {
                    logDestination.LogMessage(logMessage, messageParts, parameters, stacktrace);
                }
            }
        }

        public void SetDestinationEnabled(string destinationName, bool isEnabled)
        {
            if (!IsEnabled)
            {
                return;
            }

            var destination = Array.Find(_logDestinations, x => x.DestinationName == destinationName);

            if (destination is not null)
            {
                destination.IsEnabled = isEnabled;
            }
        }

        public void Dispose()
        {
            if (_isDisposed)
            {
                return;
            }

            foreach (var loggerDestination in _logDestinations.AsSpan())
            {
                loggerDestination.Dispose();
            }

            _isDisposed = true;
        }

        private void HandleLoggerEnabledUpdated()
        {
            if (_isEnabled)
            {
                Initialize();
            }
            else
            {
                Dispose();
            }
        }
    }
}