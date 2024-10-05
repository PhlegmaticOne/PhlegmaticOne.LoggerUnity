using System;
using OpenMyGame.LoggerUnity.Messages;
using OpenMyGame.LoggerUnity.Parsing.Models;

namespace OpenMyGame.LoggerUnity.Parameters.Message.Formats
{
    public interface IMessageFormat
    {
        string Render(LogMessage logMessage, MessagePart[] messageParts, Span<object> parameters);
    }
}