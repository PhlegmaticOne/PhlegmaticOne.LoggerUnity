using System;
using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Parsing.Models;

namespace OpenMyGame.LoggerUnity.Properties.Log.Base
{
    public interface ILogFormatProperty
    {
        string Key { get; }
        ReadOnlySpan<char> GetValue(in MessagePart messagePart, LogMessage message, in Span<object> parameters);
    }
}