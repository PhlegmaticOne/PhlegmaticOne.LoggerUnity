using System;
using OpenMyGame.LoggerUnity.Messages;

namespace OpenMyGame.LoggerUnity.Base
{
    public interface ILogger : IDisposable
    {
        bool IsEnabled { get; set; }
        void Initialize();
        LogMessage CreateMessage(LogLevel logLevel, string tag = null, Exception exception = null);
        void LogMessage(LogMessage logMessage, Span<object> parameters);
        void SetDestinationEnabled(string destinationName, bool isEnabled);
    }
}