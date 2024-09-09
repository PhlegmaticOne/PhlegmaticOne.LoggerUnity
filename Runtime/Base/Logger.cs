using System.Collections.Generic;
using OpenMyGame.LoggerUnity.Runtime.Messages;

namespace OpenMyGame.LoggerUnity.Runtime.Base
{
    public class Logger : ILogger
    {
        private readonly List<LogMessage> _messages;
        private readonly IReadOnlyList<ILogDestination> _loggerDestinations;

        public Logger(IReadOnlyList<ILogDestination> loggerDestinations, bool isEnabled)
        {
            IsEnabled = isEnabled;
            _loggerDestinations = loggerDestinations;
            _messages = new List<LogMessage>();
        }

        public bool IsEnabled { get; set; }
        public IReadOnlyList<LogMessage> Messages => _messages;

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