using System;
using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Parameters.Log.Base;
using OpenMyGame.LoggerUnity.Parsing.Models;

namespace OpenMyGame.LoggerUnity.Parameters.Log
{
    internal class LogFormatParameterNewLine : ILogFormatParameter
    {
        public string Key => "NewLine";
        
        public ReadOnlySpan<char> GetValue(MessagePart messagePart, LogMessage message, Span<object> parameters)
        {
            return Environment.NewLine;
        }
    }
}