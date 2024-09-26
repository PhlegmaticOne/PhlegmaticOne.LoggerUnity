﻿using System;
using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Parameters.Log.Base;
using OpenMyGame.LoggerUnity.Parsing.Models;

namespace OpenMyGame.LoggerUnity.Parameters.Log
{
    internal class LogFormatParameterTimeUtc : ILogFormatParameter
    {
        public string Key => "TimeUtc";
        
        public ReadOnlySpan<char> GetValue(in MessagePart messagePart, LogMessage message, in Span<object> parameters)
        {
            if (messagePart.TryGetFormat(out var format))
            {
                return DateTime.UtcNow.ToString(format.ToString());
            }

            return DateTime.UtcNow.ToString("G");
        }
    }
}