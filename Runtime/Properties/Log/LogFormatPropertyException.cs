using System;
using OpenMyGame.LoggerUnity.Runtime.Messages;
using OpenMyGame.LoggerUnity.Runtime.Parsing;
using OpenMyGame.LoggerUnity.Runtime.Properties.Base;

namespace OpenMyGame.LoggerUnity.Runtime.Properties.Log
{
    public class LogFormatPropertyException : ILogFormatProperty
    {
        public string Key => "Exception";
        
        public ReadOnlySpan<char> GetValue(in MessagePart messagePart, LogMessage message)
        {
            return message.Exception?.ToString() ?? string.Empty;
        }
    }
}