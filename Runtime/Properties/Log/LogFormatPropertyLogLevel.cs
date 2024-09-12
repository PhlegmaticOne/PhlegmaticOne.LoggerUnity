using System;
using OpenMyGame.LoggerUnity.Runtime.Base;
using OpenMyGame.LoggerUnity.Runtime.Parsing.Models;
using OpenMyGame.LoggerUnity.Runtime.Properties.Log.Base;

namespace OpenMyGame.LoggerUnity.Runtime.Properties.Log
{
    public class LogFormatPropertyLogLevel : ILogFormatProperty
    {
        public string Key => "LogLevel";
        
        public ReadOnlySpan<char> GetValue(in MessagePart messagePart, LogMessage message)
        {
            return message.LogLevel.ToString();
        }
    }
}