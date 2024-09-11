using System;
using OpenMyGame.LoggerUnity.Runtime.Messages;
using OpenMyGame.LoggerUnity.Runtime.Parsing;

namespace OpenMyGame.LoggerUnity.Runtime.Properties.Container
{
    public interface ILogFormatPropertiesContainer
    {
        ReadOnlySpan<char> RenderMessagePart(in MessagePart messagePart, LogMessage message);
    }
}