using System.Collections.Generic;
using OpenMyGame.LoggerUnity.Runtime.Messages;

namespace OpenMyGame.LoggerUnity.Runtime.Base
{
    public interface ILogger
    {
        bool IsEnabled { get; set; }
        IReadOnlyList<LogMessage> Messages { get; }
        void Log(LogMessage message);
    }
}