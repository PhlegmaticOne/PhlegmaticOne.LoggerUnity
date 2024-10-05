using System;
using OpenMyGame.LoggerUnity.Extensions;
using OpenMyGame.LoggerUnity.Messages;
using OpenMyGame.LoggerUnity.Parameters.Log.Base;
using OpenMyGame.LoggerUnity.Parsing.Models;

namespace OpenMyGame.LoggerUnity.Parameters.Log
{
    internal class LogFormatParameterException : ILogFormatParameter
    {
        public string Key => "Exception";
        
        public ReadOnlySpan<char> GetValue(MessagePart messagePart, LogMessage message, string renderedMessage)
        {
            return message.Exception?.ToStringNoStacktrace() ?? string.Empty;
        }
    }
}