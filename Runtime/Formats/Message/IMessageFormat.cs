using System;
using OpenMyGame.LoggerUnity.Parsing.Models;

namespace OpenMyGame.LoggerUnity.Formats.Message
{
    public interface IMessageFormat
    {
        string Render(MessagePart[] messageParts, Span<object> parameters);
    }
}