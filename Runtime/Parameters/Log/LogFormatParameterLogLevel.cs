using System;
using OpenMyGame.LoggerUnity.Attributes;
using OpenMyGame.LoggerUnity.Messages;
using OpenMyGame.LoggerUnity.Parameters.Log.Base;
using OpenMyGame.LoggerUnity.Parameters.Log.Helpers;
using OpenMyGame.LoggerUnity.Parsing.Models;

namespace OpenMyGame.LoggerUnity.Parameters.Log
{
    [Serializable]
    [SerializeReferenceDropdownName(KeyParameter)]
    internal class LogFormatParameterLogLevel : ILogFormatParameter
    {
        public const string KeyParameter = "LogLevel";
        public string Key => KeyParameter;
        
        public ReadOnlySpan<char> GetValue(MessagePart messagePart, LogMessage message, string renderedMessage)
        {
            if (messagePart.TryGetFormat(out var format))
            {
                return FormatLogLevel(message.LogLevel, format);
            }
            
            return message.LogLevel.ToString();
        }

        private static ReadOnlySpan<char> FormatLogLevel(LogLevel logLevel, in ReadOnlySpan<char> format)
        {
            var length = LogLevelBufferFiller.GetLengthFromFormat(logLevel, format);
            Span<char> buffer = stackalloc char[length];
            LogLevelBufferFiller.FormLogLevelView(logLevel, length, buffer);
            LogLevelBufferFiller.CaseLogLevelView(format, buffer);
            return buffer.ToString();
        }
    }
}