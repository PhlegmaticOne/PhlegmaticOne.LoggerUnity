﻿using System;
using OpenMyGame.LoggerUnity.Runtime.Base;
using OpenMyGame.LoggerUnity.Runtime.Parsing.Models;
using OpenMyGame.LoggerUnity.Runtime.Properties.Log.Base;

namespace OpenMyGame.LoggerUnity.Runtime.Properties.Log
{
    public class LogFormatPropertyException : ILogFormatProperty
    {
        public string Key => "Exception";
        
        public ReadOnlySpan<char> GetValue(in MessagePart messagePart, LogMessage message)
        {
            return message.Exception?.ToString() ?? string.Empty;
        }
    }
}