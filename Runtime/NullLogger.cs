using System;
using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Messages;

namespace OpenMyGame.LoggerUnity
{
    public class NullLogger : ILogger
    {
        public bool IsEnabled
        {
            get => false; 
            set => _ = value;
        }

        public void Initialize() { }

        public LogMessage CreateMessage(LogLevel logLevel, string tag, Exception exception) => new();

        public void LogMessage(LogMessage logMessage, Span<object> parameters) { }

        public void SetDestinationEnabled(string destinationName, bool isEnabled) { }

        public void Dispose() { }
    }
}