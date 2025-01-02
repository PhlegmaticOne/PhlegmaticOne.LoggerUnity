using System;
using Openmygame.Logger.Builders;
using Openmygame.Logger.Messages;
using Openmygame.Logger.Parsing.Models;

namespace Openmygame.Logger.Base
{
    public interface ILogDestination
    {
        bool CanLogMessage(in LogMessage logMessage);
        void Initialize(LoggerConfigurationParameters configurationParameters);
        void LogMessage(in LogMessage message, MessagePart[] messageParts, Span<object> parameters, Span<char> stacktrace);
    }
}