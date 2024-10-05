using System;
using OpenMyGame.LoggerUnity.Messages;
using OpenMyGame.LoggerUnity.Tagging.Providers;

namespace OpenMyGame.LoggerUnity.Base
{
    public interface ILogger : IDisposable
    {
        event Action<LogMessage> MessageLogged;
        event Action<LogMessageDestinationLoggedEventArgs> MessageToDestinationLogged;
        bool IsEnabled { get; set; }
        ILogTagProvider LogTagProvider { get; }
        void Initialize();
        LogMessage CreateMessage(LogLevel logLevel, int stacktraceDepthLevel);
        void LogMessage(LogMessage logMessage, Span<object> parameters);
        void SetDestinationEnabled(string destinationName, bool isEnabled);
    }
}