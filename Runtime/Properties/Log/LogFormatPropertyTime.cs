﻿using System;
using OpenMyGame.LoggerUnity.Runtime.Base;
using OpenMyGame.LoggerUnity.Runtime.Parsing.Models;
using OpenMyGame.LoggerUnity.Runtime.Properties.Log.Base;

namespace OpenMyGame.LoggerUnity.Runtime.Properties.Log
{
    internal class LogFormatPropertyTime : ILogFormatProperty
    {
        public string Key => "Time";
        
        public ReadOnlySpan<char> GetValue(in MessagePart messagePart, LogMessage message, in Span<object> parameters)
        {
            if (messagePart.TryGetFormat(out var format))
            {
                return DateTime.Now.ToString(format.ToString());
            }

            return DateTime.Now.ToString("G");
        }
    }
}