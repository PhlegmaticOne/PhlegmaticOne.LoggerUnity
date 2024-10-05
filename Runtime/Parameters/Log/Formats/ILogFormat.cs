using OpenMyGame.LoggerUnity.Base;

namespace OpenMyGame.LoggerUnity.Parameters.Log.Formats
{
    public interface ILogFormat
    {
        string Render(LogMessage logMessage, string renderedMessage);
    }
}