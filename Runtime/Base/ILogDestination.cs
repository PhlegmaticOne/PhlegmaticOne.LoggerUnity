using System;
using OpenMyGame.LoggerUnity.Messages;
using OpenMyGame.LoggerUnity.Parsing.Models;

namespace OpenMyGame.LoggerUnity.Base
{
    public interface ILogDestination : IDisposable
    {
        bool IsEnabled { get; set; }
        string DestinationName { get; }
        bool CanLogMessage(LogMessage logMessage);
        void Initialize(LoggerConfigurationParameters configurationParameters);
        string LogMessage(LogMessage message, MessagePart[] messageParts, Span<object> parameters);
    }
}