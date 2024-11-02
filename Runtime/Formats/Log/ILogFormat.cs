using System;
using OpenMyGame.LoggerUnity.Messages;
using OpenMyGame.LoggerUnity.Parsing.Models;
using SpanUtilities.StringBuilders;

namespace OpenMyGame.LoggerUnity.Formats.Log
{
    public interface ILogFormat
    {
        ValueStringBuilder Render(
            in LogMessage logMessage, ref ValueStringBuilder renderedMessage, MessagePart[] messageParts, in Span<object> parameters);
    }
}