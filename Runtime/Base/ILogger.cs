using System;
using OpenMyGame.LoggerUnity.Messages;
using OpenMyGame.LoggerUnity.Tagging.Providers;

namespace OpenMyGame.LoggerUnity.Base
{
    public interface ILogger : IDisposable
    {
        bool IsEnabled { get; set; }
        ILogTagProvider LogTagProvider { get; }
        LogMessage CreateMessage(LogLevel logLevel, int stacktraceDepthLevel);
        event Action<LogMessageLoggedEventArgs> MessageLogged;
        void Initialize();
        void LogMessage(LogMessage logMessage, Span<object> parameters);
        void SetDestinationEnabled(string destinationName, bool isEnabled);
    }
}