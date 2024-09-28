﻿using System;
using System.Threading;
using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Parameters.Log.Base;
using OpenMyGame.LoggerUnity.Parsing.Models;

namespace OpenMyGame.LoggerUnity.Parameters.Log
{
    internal class LogFormatParameterThreadId : ILogFormatParameter
    {
        public string Key => "ThreadId";
        
        public ReadOnlySpan<char> GetValue(MessagePart messagePart, LogMessage message, Span<object> parameters)
        {
            return Thread.CurrentThread.ManagedThreadId.ToString();
        }
    }
}