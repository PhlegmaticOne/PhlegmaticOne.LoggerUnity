﻿using System;
using OpenMyGame.LoggerUnity.Attributes;
using OpenMyGame.LoggerUnity.Messages;
using OpenMyGame.LoggerUnity.Parameters.Log.Base;
using OpenMyGame.LoggerUnity.Parsing.Models;

namespace OpenMyGame.LoggerUnity.Parameters.Log
{
    [Serializable]
    [SerializeReferenceDropdownName(KeyParameter)]
    internal class LogFormatParameterTime : ILogFormatParameter
    {
        public const string KeyParameter = "Time";
        public string Key => KeyParameter;
        
        public ReadOnlySpan<char> GetValue(MessagePart messagePart, in LogMessage message, string renderedMessage)
        {
            if (messagePart.TryGetFormat(out var format))
            {
                return DateTime.Now.ToString(format.ToString());
            }

            return DateTime.Now.ToString("G");
        }
    }
}