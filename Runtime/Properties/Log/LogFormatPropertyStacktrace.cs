using System;
using OpenMyGame.LoggerUnity.Runtime.Base;
using OpenMyGame.LoggerUnity.Runtime.Parsing.Models;
using OpenMyGame.LoggerUnity.Runtime.Properties.Log.Base;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.Runtime.Properties.Log
{
    internal class LogFormatPropertyStacktrace : ILogFormatProperty
    {
        public string Key => "Stacktrace";
        
        public ReadOnlySpan<char> GetValue(in MessagePart messagePart, LogMessage message, in Span<object> parameters)
        {
            return StackTraceUtility.ExtractStackTrace().AsSpan()[1352..];
        }
    }
}