using System;
using OpenMyGame.LoggerUnity.Tagging.Providers;

namespace OpenMyGame.LoggerUnity.Base
{
    public interface ILogger : IDisposable
    {
        bool IsEnabled { get; set; }
        ILogTagProvider LogTagProvider { get; }
        event Action<LogMessageLoggedEventArgs> MessageLogged;
        void Initialize();
        IMessageFormat ParseFormat(string format);
        void LogMessage(LogMessage logMessage, Span<object> parameters);
        void SetDestinationEnabled(string destinationName, bool isEnabled);
    }
}