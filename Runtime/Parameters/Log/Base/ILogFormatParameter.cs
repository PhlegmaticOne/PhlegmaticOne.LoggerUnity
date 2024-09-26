using System;
using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Parsing.Models;

namespace OpenMyGame.LoggerUnity.Parameters.Log.Base
{
    public interface ILogFormatParameter
    {
        string Key { get; }
        ReadOnlySpan<char> GetValue(in MessagePart messagePart, LogMessage message, in Span<object> parameters);
    }
}