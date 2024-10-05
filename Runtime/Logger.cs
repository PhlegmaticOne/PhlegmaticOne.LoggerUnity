using System;
using System.Collections.Generic;
using System.Linq;
using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Messages;
using OpenMyGame.LoggerUnity.Messages.Factories;
using OpenMyGame.LoggerUnity.Parsing.Base;
using OpenMyGame.LoggerUnity.Tagging.Providers;

namespace OpenMyGame.LoggerUnity
{
    internal class Logger : ILogger
    {
        private readonly IReadOnlyList<ILogDestination> _logDestinations;
        private readonly IMessageFormatParser _messageFormatParser;
        private readonly LoggerConfigurationParameters _configurationParameters;
        private readonly ILogMessageFactory _messageFactory;
        private readonly ILogTagProvider _logTagProvider;

        private bool _isEnabled;
        private bool _isDisposed;

        public Logger(
            IReadOnlyList<ILogDestination> logDestinations, 
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

        public bool IsEnabled
        {
            get => _isEnabled;
            set
            {
                _isEnabled = value;
                HandleLoggerEnabledUpdated();
            }
        }

        public ILogTagProvider LogTagProvider { get; }
        public LogMessage CreateMessage(LogLevel logLevel, int stacktraceDepthLevel)
        {
            return _messageFactory.CreateMessage(logLevel, stacktraceDepthLevel);
        }

        public event Action<LogMessageDestinationLoggedEventArgs> MessageToDestinationLogged;
        public event Action<LogMessage> MessageLogged;

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

        public void LogMessage(LogMessage logMessage, Span<object> parameters)
        {
            if (!IsEnabled)
            {
                return;
            }

            var messageParts = _messageFormatParser.Parse(logMessage.Format);
            
            foreach (var loggerDestination in _logDestinations)
            {
                if (IsLogMessageToDestination(loggerDestination, logMessage))
                {
                    loggerDestination.LogMessage(logMessage, messageParts, parameters);
                    OnMessageToDestinationLogged(logMessage, loggerDestination);
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

        private void OnMessageToDestinationLogged(LogMessage logMessage, ILogDestination loggerDestination)
        {
            MessageToDestinationLogged?.Invoke(new LogMessageDestinationLoggedEventArgs(logMessage, loggerDestination.DestinationName));
        }

        private static bool IsLogMessageToDestination(ILogDestination destination, LogMessage message)
        {
            return destination.IsEnabled && message.LogLevel >= destination.Config.MinimumLogLevel;
        }
    }
}