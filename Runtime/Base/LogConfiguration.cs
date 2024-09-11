using OpenMyGame.LoggerUnity.Runtime.Messages;

namespace OpenMyGame.LoggerUnity.Runtime.Base
{
    public abstract class LogConfiguration
    {
        protected LogConfiguration()
        {
            MinimumLogLevel = LogLevel.Debug;
            LogFormat = "{Message}";
            IsEnabled = false;
        }
        
        public LogLevel MinimumLogLevel { get; set; }
        public string LogFormat { get; set; }
        public bool IsEnabled { get; set; }
    }
}