using System;

namespace OpenMyGame.LoggerUnity.Base
{
    public interface ILogDestination
    {
        string DestinationName { get; }
        LogConfiguration Config { get; }
        bool IsEnabled { get; set; }
        void Initialize();
        void LogMessage(LogMessage message, Span<object> parameters);
        void Release();
    }
}