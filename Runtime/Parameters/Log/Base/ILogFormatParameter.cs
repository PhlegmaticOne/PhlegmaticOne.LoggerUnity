using System;
using OpenMyGame.LoggerUnity.Messages;
using OpenMyGame.LoggerUnity.Parsing.Models;

namespace OpenMyGame.LoggerUnity.Parameters.Log.Base
{
    public interface ILogFormatParameter
    {
        string Key { get; }
        ReadOnlySpan<char> GetValue(MessagePart messagePart, LogMessage message, string renderedMessage);
    }
}