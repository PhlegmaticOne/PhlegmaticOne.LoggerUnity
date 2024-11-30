using System;
using OpenMyGame.LoggerUnity.Messages;

namespace OpenMyGame.LoggerUnity.Base
{
    public interface ILogger
    {
        bool IsEnabled { get; set; }
        LogMessage CreateMessage(LogLevel logLevel, string tag = null, Exception exception = null);
        void LogMessage(LogMessage message, Span<object> parameters);
    }
}