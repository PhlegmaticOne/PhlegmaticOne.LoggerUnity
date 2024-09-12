using System;
using System.Collections.Generic;
using OpenMyGame.LoggerUnity.Runtime.Base;
using OpenMyGame.LoggerUnity.Runtime.Parsing.Base;
using OpenMyGame.LoggerUnity.Runtime.Properties.Message.Base;
using OpenMyGame.LoggerUnity.Runtime.Properties.Message.Renderer;

namespace OpenMyGame.LoggerUnity.Runtime
{
    public class Logger : ILogger
    {
        private readonly List<LogMessage> _messages;
        private readonly IReadOnlyList<ILogDestination> _loggerDestinations;
        private readonly Dictionary<Type, IMessageFormatProperty> _formatProperties;
        private readonly IMessageFormatParser _messageFormatParser;

        public Logger(
            IReadOnlyList<ILogDestination> loggerDestinations, 
            Dictionary<Type, IMessageFormatProperty> formatProperties,
            IMessageFormatParser messageFormatParser)
        {
            _loggerDestinations = loggerDestinations;
            _formatProperties = formatProperties;
            _messageFormatParser = messageFormatParser;
            _messages = new List<LogMessage>();
        }

        public bool IsEnabled { get; internal set; }
        public IReadOnlyList<LogMessage> Messages => _messages;

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

        public IMessageFormat ParseMessageFormat(string format, params object[] parameters)
        {
            var renderer = new LogMessagePartRendererMessageFormat(parameters, _formatProperties);
            return _messageFormatParser.Parse(format, renderer);
        }

        public void Log(LogMessage message)
        {
            if (!IsEnabled || message is null)
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
                    loggerDestination.LogMessage(message);
                }
            }
        }

        private static bool IsLogMessageToDestination(ILogDestination destination, LogMessage message)
        {
            return destination.IsEnabled && destination.Config.MinimumLogLevel >= message.LogLevel;
        }
    }
}