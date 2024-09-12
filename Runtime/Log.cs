using OpenMyGame.LoggerUnity.Runtime.Base;

namespace OpenMyGame.LoggerUnity.Runtime
{
    public static class Log
    {
        public static ILogger Logger { get; set; }

        public static void Debug(string format, params object[] parameters)
        {
            if (Logger is null || string.IsNullOrEmpty(format))
            {
                return;
            }
            
            var messageFormat = Logger.ParseMessageFormat(format, parameters);
            var logMessage = new LogMessage(LogLevel.Debug, messageFormat);
            Logger.Log(logMessage);
        }
    }
}