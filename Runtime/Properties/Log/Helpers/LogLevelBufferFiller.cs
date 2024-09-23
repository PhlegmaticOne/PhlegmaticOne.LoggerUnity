using System;
using OpenMyGame.LoggerUnity.Base;

namespace OpenMyGame.LoggerUnity.Properties.Log.Helpers
{
    internal static class LogLevelBufferFiller
    {
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