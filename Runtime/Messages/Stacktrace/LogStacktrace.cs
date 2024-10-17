using System;

namespace OpenMyGame.LoggerUnity.Messages.Stacktrace
{
    /// <summary>
    /// Обертка над стектрейсом сообщения
    /// </summary>
    public readonly struct LogStacktrace
    {
        private readonly string _stacktrace;
        private readonly int _userCodeStacktraceStartPosition;
        
        public static LogStacktrace Empty => new(string.Empty, -1);

        public LogStacktrace(string stacktrace, int userCodeStacktraceStartPosition)
        {
            _stacktrace = stacktrace;
            _userCodeStacktraceStartPosition = userCodeStacktraceStartPosition;
        }
        
        public bool HasValue()
        {
            return !string.IsNullOrEmpty(_stacktrace);
        }

        /// <summary>
        /// Устанавливает стектрейс, который начинается с последнего вызванного метода пользовательского кода
        /// </summary>
        public bool TryGetUserCodeStacktrace(out ReadOnlySpan<char> userCodeStacktrace)
        {
            if (!HasValue())
            {
                userCodeStacktrace = ReadOnlySpan<char>.Empty;
                return false;
            }
            
            userCodeStacktrace = _stacktrace.AsSpan()[_userCodeStacktraceStartPosition..];
            return true;
        }

        public override string ToString()
        {
            return _stacktrace;
        }
    }
}