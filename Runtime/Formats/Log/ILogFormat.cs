using System;
using Openmygame.Logger.Infrastructure.StringBuilders;
using Openmygame.Logger.Messages;

namespace Openmygame.Logger.Formats.Log
{
    public interface ILogFormat
    {
        void Render(
            ref ValueStringBuilder destination, in LogMessage logMessage,
            ref LogMessageRenderData messageRenderData, Span<char> stacktrace);
    }
}