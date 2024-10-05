using System;
using System.Diagnostics;
using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Messages;

namespace OpenMyGame.LoggerUnity
{
    public class LogWithTag
    {
        private readonly string _tag;

        public LogWithTag(string tag)
        {
            _tag = tag;
        }

        [Conditional(LoggerStaticData.ConditionalName)]
        public void Exception(Exception exception)
        {
            Log.Logger.CreateMessage(LogLevel.Fatal, stacktraceDepthLevel: 1)
                .WithTag(_tag)
                .WithException(exception)
                .Log(LoggerStaticData.ExceptionPlaceholderFormat, LoggerStaticData.ExceptionPlaceholder);
        }
        
        public LogMessage DebugMessage()
        {
            return Log.Logger
                .CreateMessage(LogLevel.Debug, stacktraceDepthLevel: 1)
                .WithTag(_tag);
        }

        public LogMessage WarningMessage()
        {
            return Log.Logger
                .CreateMessage(LogLevel.Warning, stacktraceDepthLevel: 1)
                .WithTag(_tag);
        }

        public LogMessage ErrorMessage()
        {
            return Log.Logger
                .CreateMessage(LogLevel.Error, stacktraceDepthLevel: 1)
                .WithTag(_tag);
        }

        public LogMessage FatalMessage()
        {
            return Log.Logger
                .CreateMessage(LogLevel.Fatal, stacktraceDepthLevel: 1)
                .WithTag(_tag);
        }
    }
}