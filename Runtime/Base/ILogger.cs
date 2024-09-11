using System.Collections.Generic;
using OpenMyGame.LoggerUnity.Runtime.Messages;
using OpenMyGame.LoggerUnity.Runtime.Parsing;

namespace OpenMyGame.LoggerUnity.Runtime.Base
{
    public interface ILogger
    {
        bool IsEnabled { get; set; }
        IReadOnlyList<LogMessage> Messages { get; }
        MessageFormat ParseMessage(string format, params object[] parameters);
        void Log(LogMessage message);
    }
}