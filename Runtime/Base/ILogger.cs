using System.Collections.Generic;

namespace OpenMyGame.LoggerUnity.Runtime.Base
{
    public interface ILogger
    {
        bool IsEnabled { get; }
        IReadOnlyList<LogMessage> Messages { get; }
        void Initialize();
        IMessageFormat ParseMessageFormat(string format, params object[] parameters);
        void Log(LogMessage message);
    }
}