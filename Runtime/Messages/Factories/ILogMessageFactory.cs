namespace OpenMyGame.LoggerUnity.Messages.Factories
{
    public interface ILogMessageFactory
    {
        LogMessage CreateMessage(LogLevel logLevel, int stacktraceDepthLevel);
    }
}