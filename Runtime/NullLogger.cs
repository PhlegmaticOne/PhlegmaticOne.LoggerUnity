using System;
using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Messages;

namespace OpenMyGame.LoggerUnity
{
    public class NullLogger : ILogger
    {
        public event Action<LogMessage> MessageLogged;

        public bool IsEnabled
        {
            get => false; 
            set => _ = value;
        }

        public void Initialize() { }

        public LogMessage CreateMessage(LogLevel logLevel, int stacktraceDepthLevel) => new();

        public void LogMessage(in LogMessage logMessage, in Span<object> parameters) { }

        public void SetDestinationEnabled(string destinationName, bool isEnabled) { }

        public void Dispose() { }
    }
}