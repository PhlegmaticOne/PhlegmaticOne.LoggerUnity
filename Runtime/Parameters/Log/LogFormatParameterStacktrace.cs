using System;
using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Parameters.Log.Base;
using OpenMyGame.LoggerUnity.Parsing.Models;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.Parameters.Log
{
    internal class LogFormatParameterStacktrace : ILogFormatParameter
    {
        private const string LastInformativeStacktrace = "Assets/Runtime/Base/LogMessageLoggingPart.cs";
        
        public string Key => "Stacktrace";
        
        public ReadOnlySpan<char> GetValue(MessagePart messagePart, LogMessage message, Span<object> parameters)
        {
            if (message.Exception is not null)
            {
                return ReadOnlySpan<char>.Empty;
            }
            
            var stacktrace = StackTraceUtility.ExtractStackTrace();
            var startIndex = GetStartIndex(stacktrace);
            return stacktrace[startIndex..];
        }

        private static int GetStartIndex(string stacktrace)
        {
            var index = stacktrace.IndexOf(LastInformativeStacktrace, StringComparison.OrdinalIgnoreCase);
            var startIndex = index + LastInformativeStacktrace.Length + 5;

            if (stacktrace[startIndex] == '\n')
            {
                startIndex++;
            }

            return startIndex;
        }
    }
}