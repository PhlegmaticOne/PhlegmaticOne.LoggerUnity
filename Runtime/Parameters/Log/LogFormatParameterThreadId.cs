using System;
using System.Threading;
using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Parsing.Models;
using OpenMyGame.LoggerUnity.Properties.Log.Base;

namespace OpenMyGame.LoggerUnity.Properties.Log
{
    internal class LogFormatParameterThreadId : ILogFormatParameter
    {
        public string Key => "ThreadId";
        
        public ReadOnlySpan<char> GetValue(in MessagePart messagePart, LogMessage message, in Span<object> parameters)
        {
            return Thread.CurrentThread.ManagedThreadId.ToString();
        }
    }
}