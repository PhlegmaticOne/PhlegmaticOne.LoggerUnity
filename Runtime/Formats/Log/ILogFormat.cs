using System;
using OpenMyGame.LoggerUnity.Messages;
using OpenMyGame.LoggerUnity.Parsing.Models;

namespace OpenMyGame.LoggerUnity.Formats.Log
{
    public interface ILogFormat
    {
        string Render(LogMessage logMessage, string renderedMessage, MessagePart[] messageParts, in Span<object> parameters);
    }
}