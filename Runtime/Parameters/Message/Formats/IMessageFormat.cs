using System;
using OpenMyGame.LoggerUnity.Messages;
using OpenMyGame.LoggerUnity.Parsing.Models;

namespace OpenMyGame.LoggerUnity.Parameters.Message.Formats
{
    public interface IMessageFormat
    {
        string Render(MessagePart[] messageParts, Span<object> parameters);
    }
}