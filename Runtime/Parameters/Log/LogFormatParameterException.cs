using System;
using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Extensions;
using OpenMyGame.LoggerUnity.Parameters.Log.Base;
using OpenMyGame.LoggerUnity.Parsing.Models;

namespace OpenMyGame.LoggerUnity.Parameters.Log
{
    internal class LogFormatParameterException : ILogFormatParameter
    {
        private const string NoStacktraceFormat = "ns";
        
        public string Key => "Exception";
        
        public ReadOnlySpan<char> GetValue(in MessagePart messagePart, LogMessage message, in Span<object> parameters)
        {
            if (messagePart.TryGetFormat(out var format) && message.Exception is not null)
            {
                return FormatException(message.Exception, format);
            }
            
            return message.Exception?.ToString() ?? string.Empty;
        }

        private static ReadOnlySpan<char> FormatException(Exception exception, in ReadOnlySpan<char> format)
        {
            if (format.Equals(NoStacktraceFormat, StringComparison.OrdinalIgnoreCase))
            {
                return exception.ToStringNoStacktrace();
            }

            return exception.ToString();
        }
    }
}