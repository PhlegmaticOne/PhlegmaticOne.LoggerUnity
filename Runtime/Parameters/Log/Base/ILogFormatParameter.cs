﻿using OpenMyGame.LoggerUnity.Infrastructure.StringBuilders;
using OpenMyGame.LoggerUnity.Messages;
using OpenMyGame.LoggerUnity.Parsing.Models;

namespace OpenMyGame.LoggerUnity.Parameters.Log.Base
{
    public interface ILogFormatParameter
    {
        string Key { get; }

        bool IsEmpty(in LogMessage message) => false;
        object GetValue(in LogMessage message) => null;

        void Render(ref ValueStringBuilder destination, in MessagePart messagePart, in LogMessage message);
    }
}