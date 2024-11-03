using System;
using OpenMyGame.LoggerUnity.Messages;

namespace OpenMyGame.LoggerUnity.Base
{
    public interface ILogger : IDisposable
    {
        event Action<LogMessage> MessageLogged;
        bool IsEnabled { get; set; }
        void Initialize();
        LogMessage CreateMessage(LogLevel logLevel, int stacktraceDepth);
        void LogMessage(LogMessage logMessage, Span<object> parameters);
        void SetDestinationEnabled(string destinationName, bool isEnabled);
    }
}