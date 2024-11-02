using System;
using OpenMyGame.LoggerUnity.Parsing.Models;
using SpanUtilities.StringBuilders;

namespace OpenMyGame.LoggerUnity.Formats.Message
{
    public interface IMessageFormat
    {
        void Render(ref ValueStringBuilder destination, MessagePart[] messageParts, Span<object> parameters);
    }
}