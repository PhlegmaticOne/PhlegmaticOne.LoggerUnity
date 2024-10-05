using System;
using OpenMyGame.LoggerUnity.Messages;
using OpenMyGame.LoggerUnity.Parsing.Models;

namespace OpenMyGame.LoggerUnity.Base
{
    public interface ILogDestination : IDisposable
    {
        string DestinationName { get; }
        LogConfiguration Config { get; }
        bool IsEnabled { get; set; }
        void Initialize(LoggerConfigurationParameters configurationParameters);
        void LogMessage(LogMessage message, MessagePart[] messageParts, Span<object> parameters);
    }
}