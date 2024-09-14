using System;
using OpenMyGame.LoggerUnity.Runtime.Tagging;

namespace OpenMyGame.LoggerUnity.Runtime.Base
{
    public interface ILogger
    {
        bool IsEnabled { get; }
        void Initialize();
        IMessageFormat ParseMessageFormat(string format);
        LogWithTag CreateLogWithTag(string tag);
        void Log(LogMessage message, in Span<object> parameters);
    }
}