using OpenMyGame.LoggerUnity.Runtime.Messages;

namespace OpenMyGame.LoggerUnity.Runtime.Base
{
    public static class Log
    {
        public static ILogger Logger { get; set; }

        public static void Debug(string format, params object[] parameters)
        {
            var messageFormat = Logger.ParseMessage(format, parameters);
            var logMessage = new LogMessage(LogLevel.Debug, messageFormat);
            Logger.Log(logMessage);
        }
    }
}