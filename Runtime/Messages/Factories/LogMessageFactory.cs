using OpenMyGame.LoggerUnity.Extensions;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.Messages.Factories
{
    public class LogMessageFactory : ILogMessageFactory
    {
        private const int StacktraceDepthLevelDefault = 5;
        
        private readonly bool _isExtractStacktrace;

        public LogMessageFactory(bool isExtractStacktrace)
        {
            _isExtractStacktrace = isExtractStacktrace;
        }
        
        public LogMessage CreateMessage(LogLevel logLevel, int stacktraceDepthLevel)
        {
            return new LogMessage(logLevel, CreateStacktrace(stacktraceDepthLevel), Log.Logger);
        }

        private LogStacktrace CreateStacktrace(int stacktraceDepthLevel)
        {
            if (!_isExtractStacktrace)
            {
                return LogStacktrace.Empty;
            }

            var stacktrace = StackTraceUtility.ExtractStackTrace();
            var userCodeStartPosition = stacktrace.IndexOfChar('\n', StacktraceDepthLevelDefault + stacktraceDepthLevel);
            return new LogStacktrace(stacktrace, userCodeStartPosition);
        }
    }
}