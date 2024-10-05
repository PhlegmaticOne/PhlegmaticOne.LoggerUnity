using OpenMyGame.LoggerUnity.Messages;

namespace OpenMyGame.LoggerUnity.Base
{
    public readonly struct LogMessageDestinationLoggedEventArgs
    {
        public LogMessageDestinationLoggedEventArgs(LogMessage message, string destination)
        {
            Message = message;
            Destination = destination;
        }

        public LogMessage Message { get; }
        public string Destination { get; }
    }
}