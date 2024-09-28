using System;
using System.Collections.Generic;
using System.Linq;
using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Parsing.Base;
using OpenMyGame.LoggerUnity.Tagging.Providers;

namespace OpenMyGame.LoggerUnity
{
    internal class Logger : ILogger
    {
        private readonly IReadOnlyList<ILogDestination> _logDestinations;
        private readonly IMessageFormatParser _messageFormatParser;
        private readonly ILogTagProvider _logTagProvider;

        private bool _isEnabled;
        private bool _isDisposed;

        public Logger(
            IReadOnlyList<ILogDestination> logDestinations, 
            IMessageFormatParser messageFormatParser,
            ILogTagProvider logTagProvider)
        {
            _logDestinations = logDestinations;
            _messageFormatParser = messageFormatParser;
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

        public IMessageFormat ParseFormat(string format)
        {
            return _messageFormatParser.Parse(format);
        }

        public void LogMessage(LogMessage logMessage, Span<object> parameters)
        {
            if (!IsEnabled)
            {
                return;
            }
            
            foreach (var loggerDestination in _logDestinations)
            {
                if (IsLogMessageToDestination(loggerDestination, logMessage))
                {
                    loggerDestination.LogMessage(logMessage, parameters);
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

        private static bool IsLogMessageToDestination(ILogDestination destination, LogMessage message)
        {
            return destination.IsEnabled && message.LogLevel >= destination.Config.MinimumLogLevel;
        }
    }
}