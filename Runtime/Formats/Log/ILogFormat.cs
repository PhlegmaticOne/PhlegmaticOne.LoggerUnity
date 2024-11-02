using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Messages;
using SpanUtilities.StringBuilders;

namespace OpenMyGame.LoggerUnity.Formats.Log
{
    public interface ILogFormat
    {
        void Render(ref ValueStringBuilder destination, in LogMessage logMessage, ref LogMessageRenderData messageRenderData);
    }
}