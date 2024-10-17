using System;
using System.Collections.Generic;
using System.Linq;
using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Messages;
using OpenMyGame.LoggerUnity.Messages.Factories;
using OpenMyGame.LoggerUnity.Messages.Tagging.Providers;
using OpenMyGame.LoggerUnity.Parsing.Base;

namespace OpenMyGame.LoggerUnity
{
    /// <summary>
    /// Стандартная реализация логгера
    /// </summary>
    internal class Logger : ILogger
    {
        private readonly List<ILogDestination> _logDestinations;
        private readonly IMessageFormatParser _messageFormatParser;
        private readonly LoggerConfigurationParameters _configurationParameters;
        private readonly ILogMessageFactory _messageFactory;
        private readonly ILogTagProvider _logTagProvider;

        private bool _isEnabled;
        private bool _isDisposed;

        public event Action<LogMessageDestinationLoggedEventArgs> MessageToDestinationLogged;
        public event Action<LogMessage> MessageLogged;
        
        public Logger(
            List<ILogDestination> logDestinations, 
            IMessageFormatParser messageFormatParser,
            ILogTagProvider logTagProvider,
            LoggerConfigurationParameters configurationParameters,
            ILogMessageFactory messageFactory)
        {
            _logDestinations = logDestinations;
            _messageFormatParser = messageFormatParser;
            _configurationParameters = configurationParameters;
            _messageFactory = messageFactory;
            LogTagProvider = logTagProvider;
            _isDisposed = true;
        }

        public ILogTagProvider LogTagProvider { get; }

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
            
            foreach (var loggerDestination in _logDestinations)
            {
                loggerDestination.Initialize(_configurationParameters);
            }

            _isDisposed = false;
        }

        public LogMessage CreateMessage(LogLevel logLevel, int stacktraceDepthLevel)
        {
            return _messageFactory.CreateMessage(logLevel, stacktraceDepthLevel);
        }

        public void LogMessage(in LogMessage logMessage, in Span<object> parameters)
        {
            if (!IsEnabled)
            {
                return;
            }

            var messageParts = _messageFormatParser.Parse(logMessage.Format);
            
            foreach (var logDestination in _logDestinations)
            {
                if (logDestination.CanLogMessage(logMessage))
                {
                    var renderedLogMessage = logDestination.LogMessage(logMessage, messageParts, parameters);
                    OnMessageToDestinationLogged(logMessage, renderedLogMessage, logDestination);
                }
            }
            
            MessageLogged?.Invoke(logMessage);
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

        private void OnMessageToDestinationLogged(
            in LogMessage logMessage, string renderedMessage, ILogDestination loggerDestination)
        {
            var args = new LogMessageDestinationLoggedEventArgs(
                logMessage, renderedMessage, loggerDestination.DestinationName);
            
            MessageToDestinationLogged?.Invoke(args);
        }
    }
}