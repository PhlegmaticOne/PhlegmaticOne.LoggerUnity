using OpenMyGame.LoggerUnity.Runtime.Messages;

namespace OpenMyGame.LoggerUnity.Runtime.Base
{
    public abstract class LogDestination<TConfiguration> : ILogDestination
        where TConfiguration : LogConfiguration
    {
        public TConfiguration Configuration { get; set; }
        public abstract string DestinationName { get; }
        public LogConfiguration Config => Configuration;
        public bool IsEnabled { get; set; }
        public abstract void Log(LogMessage message);
    }
}