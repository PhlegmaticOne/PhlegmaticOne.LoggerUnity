using System;
using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Messages;

namespace OpenMyGame.LoggerUnity
{
    internal class NullLogger : ILogger
    {
        public bool IsEnabled { get => false; set { } }
        public LogMessage CreateMessage(LogLevel logLevel, string tag, Exception exception) => new();
        public void LogMessage(LogMessage logMessage, Span<object> parameters) { }
    }
}