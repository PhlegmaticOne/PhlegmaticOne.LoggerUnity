using System;
using System.Diagnostics;
using OpenMyGame.LoggerUnity.Base;

namespace OpenMyGame.LoggerUnity
{
    public class LogWithTag
    {
        private readonly string _tag;

        public LogWithTag(string tag)
        {
            _tag = tag;
        }

        [Conditional("UNITY_LOGGING_ENABLED")]
        public void Exception(Exception exception)
        {
            Log.FatalMessage()
                .WithTag(_tag)
                .WithException(exception)
                .Log("{Exception}");
        }
        
        public LogMessage DebugMessage() => Message(LogLevel.Debug);
        public LogMessage WarningMessage() => Message(LogLevel.Warning);
        public LogMessage ErrorMessage() => Message(LogLevel.Error);
        public LogMessage FatalMessage() => Message(LogLevel.Fatal);
        
        private LogMessage Message(LogLevel logLevel)
        {
            return new LogMessage(logLevel, Log.Logger).WithTag(_tag);
        }
    }
}