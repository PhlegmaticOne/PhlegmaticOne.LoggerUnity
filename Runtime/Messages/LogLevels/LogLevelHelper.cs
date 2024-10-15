using System;

namespace OpenMyGame.LoggerUnity.Messages
{
    internal static class LogLevelHelper
    {
        public static LogLevel ParseFromSpan(in ReadOnlySpan<char> value)
        {
            if (value.Equals(nameof(LogLevel.Debug), StringComparison.OrdinalIgnoreCase))
            {
                return LogLevel.Debug;
            }
            
            if (value.Equals(nameof(LogLevel.Warning), StringComparison.OrdinalIgnoreCase))
            {
                return LogLevel.Warning;
            }
            
            if (value.Equals(nameof(LogLevel.Error), StringComparison.OrdinalIgnoreCase))
            {
                return LogLevel.Error;
            }
            
            if (value.Equals(nameof(LogLevel.Fatal), StringComparison.OrdinalIgnoreCase))
            {
                return LogLevel.Fatal;
            }

            throw new ArgumentException($"Unknown log level type: {value.ToString()}", nameof(value));
        }
    }
}