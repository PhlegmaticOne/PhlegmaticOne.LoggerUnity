using System;
using OpenMyGame.LoggerUnity.Runtime.Messages;
using OpenMyGame.LoggerUnity.Runtime.Parsing;
using OpenMyGame.LoggerUnity.Runtime.Properties.Base;

namespace OpenMyGame.LoggerUnity.Runtime.Properties.Log
{
    public class LogFormatPropertyNewLine : ILogFormatProperty
    {
        public string Key => "NewLine";
        
        public ReadOnlySpan<char> GetValue(in MessagePart messagePart, LogMessage message)
        {
            return Environment.NewLine;
        }
    }
}