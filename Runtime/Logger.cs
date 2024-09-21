using System;
using System.Collections.Generic;
using System.Linq;
using OpenMyGame.LoggerUnity.Runtime.Base;
using OpenMyGame.LoggerUnity.Runtime.Parsing.Base;
using OpenMyGame.LoggerUnity.Runtime.Tagging;
using OpenMyGame.LoggerUnity.Runtime.Tagging.Factories;

namespace OpenMyGame.LoggerUnity.Runtime
{
    internal class Logger : ILogger
    {
        private readonly IReadOnlyList<ILogDestination> _logDestinations;
        private readonly IMessageFormatParser _messageFormatParser;
        private readonly ILogWithTagFactory _logWithTagFactory;

        private bool _isEnabled;
        private bool _isDisposed;

        public Logger(
            IReadOnlyList<ILogDestination> logDestinations, 
            IMessageFormatParser messageFormatParser,
            ILogWithTagFactory logWithTagFactory)
        {
            _logDestinations = logDestinations;
            _messageFormatParser = messageFormatParser;
            _logWithTagFactory = logWithTagFactory;
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

        public event Action<LogMessage> MessageLogged;

        public void Initialize()
        {
            if (!IsEnabled)
            {
                return;
            }
            
            foreach (var loggerDestination in _logDestinations)
            {
                loggerDestination.Initialize();
            }

            _isDisposed = false;
        }

        public LogWithTag CreateLogWithTag(string tag)
        {
            return _logWithTagFactory.Create(tag);
        }

        public void LogMessage(LogLevel logLevel, string format, in Span<object> parameters, Exception exception = null)
        {
            if (!IsEnabled)
            {
                return;
            }
            
            var messageFormat = _messageFormatParser.Parse(format);
            var logMessage = new LogMessage(logLevel, messageFormat, exception);
            LogMessage(logMessage, parameters);
            MessageLogged?.Invoke(logMessage);
            logMessage.Dispose();
        }

        public void SetDestinationEnabled(string destinationName, bool isEnabled)
        {
            if (!IsEnabled)
            {
                return;
            }
            
            var destination = _logDestinations.FirstOrDefault(x => x.DestinationName == destinationName);

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
            
            foreach (var loggerDestination in _logDestinations)
            {
                loggerDestination.Release();
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

        private void LogMessage(LogMessage message, in Span<object> parameters)
        {
            foreach (var loggerDestination in _logDestinations)
            {
                if (IsLogMessageToDestination(loggerDestination, message))
                {
                    loggerDestination.LogMessage(message, parameters);
                }
            }
        }

        private static bool IsLogMessageToDestination(ILogDestination destination, LogMessage message)
        {
            return destination.IsEnabled && message.LogLevel >= destination.Config.MinimumLogLevel;
        }
    }
}