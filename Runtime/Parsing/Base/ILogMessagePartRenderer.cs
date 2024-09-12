using System;
using OpenMyGame.LoggerUnity.Runtime.Base;
using OpenMyGame.LoggerUnity.Runtime.Parsing.Models;

namespace OpenMyGame.LoggerUnity.Runtime.Parsing.Base
{
    public interface ILogMessagePartRenderer
    {
        ReadOnlySpan<char> Render(in MessagePart messagePart, LogMessage message);
    }
}