using System;
using OpenMyGame.LoggerUnity.Runtime.Messages;
using OpenMyGame.LoggerUnity.Runtime.Parsing;
using OpenMyGame.LoggerUnity.Runtime.Properties.Base;

namespace OpenMyGame.LoggerUnity.Runtime.Properties.Log
{
    public class LogFormatPropertyTime : ILogFormatProperty
    {
        public string Key => "Time";
        public ReadOnlySpan<char> GetValue(in MessagePart messagePart, LogMessage message)
        {
            return DateTime.Now.ToString("g");
        }
    }
}