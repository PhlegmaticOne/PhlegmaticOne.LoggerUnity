using System;
using System.Collections.Generic;
using OpenMyGame.LoggerUnity.Runtime.Base;
using OpenMyGame.LoggerUnity.Runtime.Parsing.Base;
using OpenMyGame.LoggerUnity.Runtime.Tagging;
using OpenMyGame.LoggerUnity.Runtime.Tagging.Factories;

namespace OpenMyGame.LoggerUnity.Runtime
{
    public class Logger : ILogger
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

        public IMessageFormat ParseMessageFormat(string format)
        {
            return _messageFormatParser.Parse(format);
        }

        public LogWithTag CreateLogWithTag(string tag)
        {
            return _logWithTagFactory.Create(tag);
        }

        public void Log(LogMessage message, in Span<object> parameters)
        {
            if (!IsEnabled || message is null)
            {
                return;
            }
            
            LogMessage(message, parameters);
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
    }
}