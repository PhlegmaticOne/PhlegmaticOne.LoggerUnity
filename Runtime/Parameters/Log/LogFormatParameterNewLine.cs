using System;
using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Parsing.Models;
using OpenMyGame.LoggerUnity.Properties.Log.Base;

namespace OpenMyGame.LoggerUnity.Properties.Log
{
    internal class LogFormatParameterNewLine : ILogFormatParameter
    {
        public string Key => "NewLine";
        
        public ReadOnlySpan<char> GetValue(in MessagePart messagePart, LogMessage message, in Span<object> parameters)
        {
            return Environment.NewLine;
        }
    }
}