using System;
using OpenMyGame.LoggerUnity.Runtime.Tagging;

namespace OpenMyGame.LoggerUnity.Runtime.Base
{
    public interface ILogger : IDisposable
    {
        bool IsEnabled { get; set; }
        event Action<LogMessage> MessageLogged; 
        void Initialize();
        LogWithTag CreateLogWithTag(string tag);
        void LogMessage(LogLevel logLevel, string format, in Span<object> parameters, Exception exception = null);
        void SetDestinationEnabled(string destinationName, bool isEnabled);
    }
}