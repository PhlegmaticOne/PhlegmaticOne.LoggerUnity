using System;
using OpenMyGame.LoggerUnity.Runtime.Messages;
using OpenMyGame.LoggerUnity.Runtime.Parsing;

namespace OpenMyGame.LoggerUnity.Runtime.Properties.Base
{
    public interface ILogFormatProperty
    {
        string Key { get; }
        ReadOnlySpan<char> GetValue(in MessagePart messagePart, LogMessage message);
    }
}