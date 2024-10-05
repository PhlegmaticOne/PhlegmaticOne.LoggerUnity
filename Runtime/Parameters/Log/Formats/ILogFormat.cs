using OpenMyGame.LoggerUnity.Messages;

namespace OpenMyGame.LoggerUnity.Parameters.Log.Formats
{
    public interface ILogFormat
    {
        string Render(LogMessage logMessage, string renderedMessage);
    }
}