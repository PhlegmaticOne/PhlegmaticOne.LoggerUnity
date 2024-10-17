using System;
using OpenMyGame.LoggerUnity.Messages;
using OpenMyGame.LoggerUnity.Parsing.Models;

namespace OpenMyGame.LoggerUnity.Base
{
    public interface ILogDestination : IDisposable
    {
        bool IsEnabled { get; set; }
        string DestinationName { get; }
        bool CanLogMessage(in LogMessage logMessage);
        void Initialize(LoggerConfigurationParameters configurationParameters);
        string LogMessage(in LogMessage message, MessagePart[] messageParts, Span<object> parameters);
    }
}