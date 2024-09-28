using System;
using OpenMyGame.LoggerUnity.Tagging.Factories;

namespace OpenMyGame.LoggerUnity.Base
{
    public interface ILogger : IDisposable
    {
        bool IsEnabled { get; set; }
        ILogTagProvider LogTagProvider { get; }
        event Action<LogMessage> MessageLogged;
        void Initialize();
        IMessageFormat ParseFormat(string format);
        void LogMessage(LogMessage logMessage, in Span<object> parameters);
        void SetDestinationEnabled(string destinationName, bool isEnabled);
    }
}