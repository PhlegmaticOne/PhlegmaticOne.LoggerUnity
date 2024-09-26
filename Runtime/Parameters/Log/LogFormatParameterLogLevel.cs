using System;
using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Extensions;
using OpenMyGame.LoggerUnity.Parameters.Log.Base;
using OpenMyGame.LoggerUnity.Parameters.Log.Helpers;
using OpenMyGame.LoggerUnity.Parsing.Models;

namespace OpenMyGame.LoggerUnity.Parameters.Log
{
    internal class LogFormatParameterLogLevel : ILogFormatParameter
    {
        public string Key => "LogLevel";
        
        public ReadOnlySpan<char> GetValue(in MessagePart messagePart, LogMessage message, in Span<object> parameters)
        {
            if (messagePart.TryGetFormat(out var format))
            {
                return FormatLogLevel(message.LogLevel, format);
            }
            
            return message.LogLevel.ToString();
        }

        private static ReadOnlySpan<char> FormatLogLevel(LogLevel logLevel, in ReadOnlySpan<char> format)
        {
            var length = GetLengthFromFormat(logLevel, format);
            Span<char> buffer = stackalloc char[length];
            LogLevelBufferFiller.FormLogLevelView(logLevel, length, buffer);
            CaseLogLevelView(format, buffer);
            return buffer.ToString();
        }

        private static void CaseLogLevelView(in ReadOnlySpan<char> format, in Span<char> result)
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

        private static int GetLengthFromFormat(LogLevel logLevel, in ReadOnlySpan<char> format)
        {
            var lengthChar = format[^1];
            
            if (int.TryParse(lengthChar.ToString(), out var length))
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
    }
}