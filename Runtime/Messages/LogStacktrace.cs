using System;

namespace OpenMyGame.LoggerUnity.Messages
{
    public class LogStacktrace
    {
        public static LogStacktrace Empty => new(string.Empty, -1);
        
        public string Stacktrace { get; }
        public int UserCodeStacktraceStartPosition { get; }

        public LogStacktrace(string stacktrace, int userCodeStacktraceStartPosition)
        {
            Stacktrace = stacktrace;
            UserCodeStacktraceStartPosition = userCodeStacktraceStartPosition;
        }
        
        public bool HasValue()
        {
            return !string.IsNullOrEmpty(Stacktrace);
        }

        public bool TryGetUserCodeStacktrace(out ReadOnlySpan<char> userCodeStacktrace)
        {
            userCodeStacktrace = Stacktrace.AsSpan()[UserCodeStacktraceStartPosition..];
            return true;
        }
    }
}