using System;
using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Parsing.Models;
using OpenMyGame.LoggerUnity.Properties.Log.Base;

namespace OpenMyGame.LoggerUnity.Properties.Log
{
    internal class LogFormatParameterTime : ILogFormatParameter
    {
        public string Key => "Time";
        
        public ReadOnlySpan<char> GetValue(in MessagePart messagePart, LogMessage message, in Span<object> parameters)
        {
            if (messagePart.TryGetFormat(out var format))
            {
                return DateTime.Now.ToString(format.ToString());
            }

            return DateTime.Now.ToString("G");
        }
    }
}