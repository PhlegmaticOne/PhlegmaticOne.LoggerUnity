﻿using System;
using OpenMyGame.LoggerUnity.Configuration.Attributes;
using OpenMyGame.LoggerUnity.Infrastructure.StringBuilders;
using OpenMyGame.LoggerUnity.Messages;
using OpenMyGame.LoggerUnity.Parameters.Log.Base;
using OpenMyGame.LoggerUnity.Parsing.Models;

namespace OpenMyGame.LoggerUnity.Parameters.Log
{
    [Serializable]
    [SerializeReferenceDropdownName(KeyParameter)]
    internal class LogFormatParameterTimeUtc : ILogFormatParameter
    {
        public const string KeyParameter = "TimeUtc";
        public string Key => KeyParameter;

        public void Render(ref ValueStringBuilder destination, in MessagePart messagePart, in LogMessage message)
        {
            if (messagePart.TryGetFormat(out var format))
            {
                destination.Append(DateTime.UtcNow, format);
                return;
            }

            destination.Append(DateTime.UtcNow);
        }
    }
}