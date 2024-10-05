using System;
using OpenMyGame.LoggerUnity.Messages;
using OpenMyGame.LoggerUnity.Parsing.Models;

namespace OpenMyGame.LoggerUnity.Base
{
    public interface ILogDestination : IDisposable
    {
        bool IsEnabled { get; set; }
        string DestinationName { get; }
        LogConfiguration Config { get; }
        void Initialize(LoggerConfigurationParameters configurationParameters);
        void LogMessage(LogMessage message, MessagePart[] messageParts, Span<object> parameters);
    }
}