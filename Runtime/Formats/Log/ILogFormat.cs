using System;
using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Infrastructure.StringBuilders;
using OpenMyGame.LoggerUnity.Messages;

namespace OpenMyGame.LoggerUnity.Formats.Log
{
    public interface ILogFormat
    {
        void Render(
            ref ValueStringBuilder destination, in LogMessage logMessage,
            ref LogMessageRenderData messageRenderData, in ReadOnlySpan<byte> stacktrace);
    }
}