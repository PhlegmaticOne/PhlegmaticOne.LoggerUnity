using OpenMyGame.LoggerUnity.Runtime.Attributes;
using OpenMyGame.LoggerUnity.Runtime.Base;

namespace OpenMyGame.LoggerUnity.Runtime
{
    public static class Log
    {
        public static ILogger Logger { get; set; }

        [MessageTemplateFormatMethod("format")]
        public static void Debug(string format, params object[] parameters)
        {
            LogMessage(LogLevel.Debug, format, parameters);
        }
        
        [MessageTemplateFormatMethod("format")]
        public static void Warning(string format, params object[] parameters)
        {
            LogMessage(LogLevel.Warning, format, parameters);
        }
        
        [MessageTemplateFormatMethod("format")]
        public static void Error(string format, params object[] parameters)
        {
            LogMessage(LogLevel.Error, format, parameters);
        }
        
        [MessageTemplateFormatMethod("format")]
        public static void Fatal(string format, params object[] parameters)
        {
            LogMessage(LogLevel.Fatal, format, parameters);
        }

        private static void LogMessage(LogLevel logLevel, string format, object[] parameters)
        {
            if (Logger is null || string.IsNullOrEmpty(format))
            {
                return;
            }
            
            var messageFormat = Logger.ParseMessageFormat(format, parameters);
            var logMessage = new LogMessage(logLevel, messageFormat);
            Logger.Log(logMessage);
        }
    }
}