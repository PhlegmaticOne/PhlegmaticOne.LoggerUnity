using System;
using OpenMyGame.LoggerUnity.Builders;
using OpenMyGame.LoggerUnity.Messages;
using OpenMyGame.LoggerUnity.Parsing.Models;

namespace OpenMyGame.LoggerUnity.Base
{
    public interface ILogDestination
    {
        bool CanLogMessage(in LogMessage logMessage);
        void Initialize(LoggerConfigurationParameters configurationParameters);
        void LogMessage(in LogMessage message, MessagePart[] messageParts, Span<object> parameters, Span<char> stacktrace);
    }
}