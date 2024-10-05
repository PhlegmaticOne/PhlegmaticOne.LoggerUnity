using System;
using OpenMyGame.LoggerUnity.Parsing.Models;

namespace OpenMyGame.LoggerUnity.Base
{
    public interface ILogDestination : IDisposable
    {
        string DestinationName { get; }
        LogConfiguration Config { get; }
        bool IsEnabled { get; set; }
        void Initialize(LoggerDependencies dependencies);
        void LogMessage(LogMessage message, MessagePart[] messageParts, Span<object> parameters);
    }
}