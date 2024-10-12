using System;
using OpenMyGame.LoggerUnity.Attributes;
using OpenMyGame.LoggerUnity.Messages;
using OpenMyGame.LoggerUnity.Parameters.Log.Base;
using OpenMyGame.LoggerUnity.Parsing.Models;

namespace OpenMyGame.LoggerUnity.Parameters.Log
{
    [SerializeReferenceDropdownName(KeyParameter)]
    internal class LogFormatParameterTimeUtc : ILogFormatParameter
    {
        public const string KeyParameter = "TimeUtc";
        public string Key => KeyParameter;
        
        public ReadOnlySpan<char> GetValue(MessagePart messagePart, LogMessage message, string renderedMessage)
        {
            if (messagePart.TryGetFormat(out var format))
            {
                return DateTime.UtcNow.ToString(format.ToString());
            }

            return DateTime.UtcNow.ToString("G");
        }
    }
}