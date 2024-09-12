namespace OpenMyGame.LoggerUnity.Runtime.Base
{
    public interface ILogDestination
    {
        string DestinationName { get; }
        LogConfiguration Config { get; }
        bool IsEnabled { get; set; }
        void Initialize();
        void LogMessage(LogMessage message);
        string RenderMessage(LogMessage message);
    }
}