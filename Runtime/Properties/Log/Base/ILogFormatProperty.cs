using System;
using OpenMyGame.LoggerUnity.Runtime.Base;
using OpenMyGame.LoggerUnity.Runtime.Parsing.Models;

namespace OpenMyGame.LoggerUnity.Runtime.Properties.Log.Base
{
    public interface ILogFormatProperty
    {
        string Key { get; }
        ReadOnlySpan<char> GetValue(in MessagePart messagePart, LogMessage message);
    }
}