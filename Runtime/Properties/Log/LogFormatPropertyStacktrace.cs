using System;
using OpenMyGame.LoggerUnity.Runtime.Base;
using OpenMyGame.LoggerUnity.Runtime.Parsing.Models;
using OpenMyGame.LoggerUnity.Runtime.Properties.Log.Base;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.Runtime.Properties.Log
{
    internal class LogFormatPropertyStacktrace : ILogFormatProperty
    {
        private const string LastInformativeStacktrace = "Assets/Runtime/Log.cs";
        
        public string Key => "Stacktrace";
        
        public ReadOnlySpan<char> GetValue(in MessagePart messagePart, LogMessage message, in Span<object> parameters)
        {
            var stacktrace = StackTraceUtility.ExtractStackTrace();
            var index = stacktrace.LastIndexOf(LastInformativeStacktrace, StringComparison.OrdinalIgnoreCase);
            var startIndex = index + LastInformativeStacktrace.Length + 5;
            return stacktrace[startIndex..];
        }
    }
}