using System;
using System.Collections.Generic;
using OpenMyGame.LoggerUnity.Runtime.Messages;
using OpenMyGame.LoggerUnity.Runtime.Parsing;
using OpenMyGame.LoggerUnity.Runtime.Properties.Base;
using OpenMyGame.LoggerUnity.Runtime.Properties.Container;

namespace OpenMyGame.LoggerUnity.Runtime.Base
{
    public class Logger : ILogger
    {
        private readonly List<LogMessage> _messages;
        private readonly IReadOnlyList<ILogDestination> _loggerDestinations;
        private readonly Dictionary<Type, ILogMessageFormatProperty> _formatProperties;
        private readonly ILogMessagePartRenderer _partRenderer;
        private readonly IMessageFormatParser _messageFormatParser;

        public Logger(
            IReadOnlyList<ILogDestination> loggerDestinations, 
            Dictionary<Type, ILogMessageFormatProperty> formatProperties,
            ILogMessagePartRenderer partRenderer, 
            bool isEnabled)
        {
            IsEnabled = isEnabled;
            _loggerDestinations = loggerDestinations;
            _formatProperties = formatProperties;
            _partRenderer = partRenderer;
            _messageFormatParser = new MessageFormatParser();
            _messages = new List<LogMessage>();
        }

        public bool IsEnabled { get; set; }
        public IReadOnlyList<LogMessage> Messages => _messages;

        public MessageFormat ParseMessage(string format, params object[] parameters)
        {
            var renderer = new LogMessagePartRendererParameters(parameters, _formatProperties);
            return _messageFormatParser.Parse(format, renderer);
        }

        public void Log(LogMessage message)
        {
            if (!IsEnabled)
            {
                return;
            }
            
            _messages.Add(message);
            LogMessage(message);
        }
        
        private void LogMessage(LogMessage message)
        {
            foreach (var loggerDestination in _loggerDestinations)
            {
                if (IsLogMessageToDestination(loggerDestination, message))
                {
                    loggerDestination.Log(message);
                }
            }
        }

        private static bool IsLogMessageToDestination(ILogDestination destination, LogMessage message)
        {
            return destination.IsEnabled && destination.Config.MinimumLogLevel >= message.LogLevel;
        }
    }
}