using System;
using Openmygame.Logger.Base;
using Openmygame.Logger.Messages;

namespace Openmygame.Logger
{
    internal class NullLogger : ILogger
    {
        public bool IsEnabled { get => false; set { } }
        public LogMessage CreateMessage(LogLevel logLevel, string tag, Exception exception) => new();
        public void LogMessage(LogMessage logMessage, Span<object> parameters) { }
    }
}