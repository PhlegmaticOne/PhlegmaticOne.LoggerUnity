using System;
using OpenMyGame.LoggerUnity.Infrastructure.StringBuilders;
using OpenMyGame.LoggerUnity.Parsing.Models;

namespace OpenMyGame.LoggerUnity.Formats.Message
{
    public interface IMessageFormat
    {
        void Render(ref ValueStringBuilder destination, MessagePart[] messageParts, Span<object> parameters);
    }
}