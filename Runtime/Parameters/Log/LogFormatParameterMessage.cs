using System;
using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Parameters.Log.Base;
using OpenMyGame.LoggerUnity.Parsing.Models;

namespace OpenMyGame.LoggerUnity.Parameters.Log
{
    internal class LogFormatParameterMessage : ILogFormatParameter
    {
        public string Key => "Message";
        
        public ReadOnlySpan<char> GetValue(in MessagePart messagePart, LogMessage message, in Span<object> parameters)
        {
            return message.Render(parameters);
        }
    }
}