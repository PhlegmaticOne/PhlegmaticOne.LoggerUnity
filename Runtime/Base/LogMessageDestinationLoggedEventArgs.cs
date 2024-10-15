using OpenMyGame.LoggerUnity.Messages;

namespace OpenMyGame.LoggerUnity.Base
{
    public readonly struct LogMessageDestinationLoggedEventArgs
    {
        public LogMessageDestinationLoggedEventArgs(LogMessage message, string renderedMessage, string destination)
        {
            Message = message;
            RenderedMessage = renderedMessage;
            Destination = destination;
        }

        public LogMessage Message { get; }
        public string RenderedMessage { get; }
        public string Destination { get; }
    }
}