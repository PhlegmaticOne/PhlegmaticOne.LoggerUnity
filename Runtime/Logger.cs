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
        private readonly IReadOnlyList<ILogDestination> _loggerDestinations;
        private readonly IMessageFormatParser _messageFormatParser;
        private readonly ILogWithTagFactory _logWithTagFactory;

        public Logger(
            IReadOnlyList<ILogDestination> loggerDestinations, 
            IMessageFormatParser messageFormatParser,
            ILogWithTagFactory logWithTagFactory)
        {
            _loggerDestinations = loggerDestinations;
            _messageFormatParser = messageFormatParser;
            _logWithTagFactory = logWithTagFactory;
        }

        public bool IsEnabled { get; internal set; }
        
        public void Initialize()
        {
            if (!IsEnabled)
            {
                return;
            }
            
            foreach (var loggerDestination in _loggerDestinations)
            {
                loggerDestination.Initialize();
            }
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
        }

        public void SetDestinationEnabled(string destinationName, bool isEnabled)
        {
            if (!IsEnabled)
            {
                return;
            }
            
            var destination = _loggerDestinations.FirstOrDefault(x => x.DestinationName == destinationName);

            if (destination is not null)
            {
                destination.IsEnabled = isEnabled;
            }
        }

        private void LogMessage(LogMessage message, in Span<object> parameters)
        {
            foreach (var loggerDestination in _loggerDestinations)
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

        public void Dispose()
        {
            if (!IsEnabled)
            {
                return;
            }
            
            foreach (var loggerDestination in _loggerDestinations)
            {
                loggerDestination.Release();
            }
        }
    }
}