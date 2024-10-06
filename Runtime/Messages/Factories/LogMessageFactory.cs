using System.Threading;
using OpenMyGame.LoggerUnity.Extensions;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.Messages.Factories
{
    internal class LogMessageFactory : ILogMessageFactory
    {
        private readonly bool _isExtractStacktrace;
        private readonly int _startStacktraceDepthLevel;

        private int _currentMessageId = -1;

        public LogMessageFactory(bool isExtractStacktrace, int startStacktraceDepthLevel)
        {
            _isExtractStacktrace = isExtractStacktrace;
            _startStacktraceDepthLevel = startStacktraceDepthLevel;
        }
        
        public LogMessage CreateMessage(LogLevel logLevel, int stacktraceDepthLevel)
        {
            return new LogMessage(
                Interlocked.Increment(ref _currentMessageId), 
                logLevel, 
                CreateStacktrace(stacktraceDepthLevel), 
                Log.Logger);
        }

        private LogStacktrace CreateStacktrace(int stacktraceDepthLevel)
        {
            if (!_isExtractStacktrace)
            {
                return LogStacktrace.Empty;
            }

            var stacktrace = StackTraceUtility.ExtractStackTrace();
            var userCodeStartPosition = stacktrace.IndexOfChar('\n', _startStacktraceDepthLevel + stacktraceDepthLevel);
            return new LogStacktrace(stacktrace, userCodeStartPosition);
        }
    }
}