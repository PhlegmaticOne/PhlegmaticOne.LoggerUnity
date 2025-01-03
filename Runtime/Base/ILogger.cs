using System;
using Openmygame.Logger.Messages;

namespace Openmygame.Logger.Base
{
    public interface ILogger
    {
        bool IsEnabled { get; set; }
        void LogMessage(LogMessage message, Span<object> parameters);
    }
}