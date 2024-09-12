using System;
using OpenMyGame.LoggerUnity.Runtime.Messages;
using OpenMyGame.LoggerUnity.Runtime.Parsing;

namespace OpenMyGame.LoggerUnity.Runtime.Properties.Container
{
    public interface ILogMessagePartRenderer
    {
        ReadOnlySpan<char> Render(in MessagePart messagePart, LogMessage message);
    }
}