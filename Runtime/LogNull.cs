using System;
using Openmygame.Logger.Base;
using Openmygame.Logger.Messages;

namespace Openmygame.Logger
{
    internal sealed class LogNull : ILogger
    {
        public bool IsEnabled { get => false; set { } }
        public void LogMessage(LogMessage logMessage, Span<object> parameters) { }
    }
}