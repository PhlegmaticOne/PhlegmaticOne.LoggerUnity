using System.Collections.Generic;
using OpenMyGame.LoggerUnity.Runtime.Messages;
using OpenMyGame.LoggerUnity.Runtime.Parsing;

namespace OpenMyGame.LoggerUnity.Runtime.Base
{
    public class Logger : ILogger
    {
        private readonly List<LogMessage> _messages;
        private readonly IReadOnlyList<ILogDestination> _loggerDestinations;
        private readonly IMessageFormatParser _messageFormatParser;

        public Logger(IReadOnlyList<ILogDestination> loggerDestinations, IMessageFormatParser messageFormatParser, bool isEnabled)
        {
            IsEnabled = isEnabled;
            _loggerDestinations = loggerDestinations;
            _messageFormatParser = messageFormatParser;
            _messages = new List<LogMessage>();
        }

        public bool IsEnabled { get; set; }
        public IReadOnlyList<LogMessage> Messages => _messages;

        public MessageFormat ParseMessage(string format, params object[] parameters)
        {
            return _messageFormatParser.Parse(format, parameters);
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
                if (DestinationIsLogMessage(loggerDestination, message))
                {
                    loggerDestination.Log(message);
                }
            }
        }

        private static bool DestinationIsLogMessage(ILogDestination destination, LogMessage message)
        {
            return destination.IsEnabled && destination.Config.MinimumLogLevel >= message.LogLevel;
        }
    }
}