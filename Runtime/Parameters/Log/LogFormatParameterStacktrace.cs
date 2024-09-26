using System;
using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Parameters.Log.Base;
using OpenMyGame.LoggerUnity.Parsing.Models;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.Parameters.Log
{
    internal class LogFormatParameterStacktrace : ILogFormatParameter
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