using System;
using OpenMyGame.LoggerUnity.Messages;

namespace OpenMyGame.LoggerUnity.Base
{
    public interface ILogger : IDisposable
    {
        event Action<LogMessage> MessageLogged;
        event Action<LogMessageDestinationLoggedEventArgs> MessageToDestinationLogged;
        bool IsEnabled { get; set; }
        void Initialize();
        LogMessage CreateMessage(LogLevel logLevel, int stacktraceDepthLevel);
        void LogMessage(in LogMessage logMessage, in Span<object> parameters);
        void SetDestinationEnabled(string destinationName, bool isEnabled);
    }
}