using System;
using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Parameters.Log.Base;
using OpenMyGame.LoggerUnity.Parsing.Models;

namespace OpenMyGame.LoggerUnity.Parameters.Log
{
    internal class LogFormatParameterTime : ILogFormatParameter
    {
        public string Key => "Time";
        
        public ReadOnlySpan<char> GetValue(MessagePart messagePart, LogMessage message, Span<object> parameters)
        {
            if (messagePart.TryGetFormat(out var format))
            {
                return DateTime.Now.ToString(format.ToString());
            }

            return DateTime.Now.ToString("G");
        }
    }
}