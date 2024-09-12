using System.Collections.Generic;

namespace OpenMyGame.LoggerUnity.Runtime.Base
{
    public interface ILogger
    {
        bool IsEnabled { get; set; }
        IReadOnlyList<LogMessage> Messages { get; }
        void Initialize();
        IMessageFormat ParseMessage(string format, params object[] parameters);
        void Log(LogMessage message);
    }
}