using System;
using OpenMyGame.LoggerUnity.Extensions;
using OpenMyGame.LoggerUnity.Messages;

namespace OpenMyGame.LoggerUnity.Parameters.Log.Helpers
{
    internal static class LogLevelBufferFiller
    {
        public static int GetLengthFromFormat(LogLevel logLevel, in ReadOnlySpan<char> format)
        {
            var lengthChar = format[^1];
            
            if (int.TryParse(lengthChar.ToString(), out var length) && length is 1 or 3)
            {
                return length;
            }

            return logLevel switch
            {
                LogLevel.Debug => 5,
                LogLevel.Warning => 7,
                LogLevel.Error => 5,
                LogLevel.Fatal => 5,
                _ => throw new ArgumentOutOfRangeException(nameof(logLevel), logLevel, null)
            };
        }
        
        public static void FormLogLevelView(LogLevel logLevel, int length, in Span<char> buffer)
        {
            switch (length)
            {
                case 1:
                    GetLogLevelViewLength1(logLevel, in buffer);
                    break;
                case 3:
                    GetLogLevelViewLength3(logLevel, in buffer);
                    break;
                default:
                    GetLogLevelView(logLevel, in buffer);
                    break;
            }
        }
        
        public static void CaseLogLevelView(in ReadOnlySpan<char> format, in Span<char> result)
        {
            var casingFormat = format[0];

            switch (casingFormat)
            {
                case 'u':
                    result.ToUpperCase();
                    break;
                case 'l':
                    result.ToLowerCase();
                    break;
            }
        }

        private static void GetLogLevelViewLength1(LogLevel logLevel, in Span<char> buffer)
        {
            switch (logLevel)
            {
                case LogLevel.Debug:
                    buffer[0] = 'D';
                    break;
                case LogLevel.Warning:
                    buffer[0] = 'W';
                    break;
                case LogLevel.Error:
                    buffer[0] = 'E';
                    break;
                case LogLevel.Fatal:
                    buffer[0] = 'F';
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(logLevel), logLevel, null);
            }
        }

        private static void GetLogLevelViewLength3(LogLevel logLevel, in Span<char> buffer)
        {
            switch (logLevel)
            {
                case LogLevel.Debug:
                    buffer[0] = 'D';
                    buffer[1] = 'b';
                    buffer[2] = 'g';
                    break;
                case LogLevel.Warning:
                    buffer[0] = 'W';
                    buffer[1] = 'r';
                    buffer[2] = 'n';
                    break;
                case LogLevel.Error:
                    buffer[0] = 'E';
                    buffer[1] = 'r';
                    buffer[2] = 'r';
                    break;
                case LogLevel.Fatal:
                    buffer[0] = 'F';
                    buffer[1] = 't';
                    buffer[2] = 'l';
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(logLevel), logLevel, null);
            }
        }
        
        private static void GetLogLevelView(LogLevel logLevel, in Span<char> buffer)
        {
            switch (logLevel)
            {
                case LogLevel.Debug:
                    buffer[0] = 'D';
                    buffer[1] = 'e';
                    buffer[2] = 'b';
                    buffer[3] = 'u';
                    buffer[4] = 'g';
                    break;
                case LogLevel.Warning:
                    buffer[0] = 'W';
                    buffer[1] = 'a';
                    buffer[2] = 'r';
                    buffer[3] = 'n';
                    buffer[4] = 'i';
                    buffer[5] = 'n';
                    buffer[6] = 'g';
                    break;
                case LogLevel.Error:
                    buffer[0] = 'E';
                    buffer[1] = 'r';
                    buffer[2] = 'r';
                    buffer[3] = 'o';
                    buffer[4] = 'r';
                    break;
                case LogLevel.Fatal:
                    buffer[0] = 'F';
                    buffer[1] = 'a';
                    buffer[2] = 't';
                    buffer[3] = 'a';
                    buffer[4] = 'l';
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(logLevel), logLevel, null);
            }
        }
    }
}