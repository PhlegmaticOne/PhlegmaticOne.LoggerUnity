using System;
using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Parsing.Models;
using OpenMyGame.LoggerUnity.Properties.Log.Base;

namespace OpenMyGame.LoggerUnity.Properties.Log
{
    internal class LogFormatPropertyMessage : ILogFormatProperty
    {
        public string Key => "Message";
        
        public ReadOnlySpan<char> GetValue(in MessagePart messagePart, LogMessage message, in Span<object> parameters)
        {
            return message.Render(parameters);
        }
    }
}