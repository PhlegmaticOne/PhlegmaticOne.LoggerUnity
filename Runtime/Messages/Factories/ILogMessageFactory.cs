namespace OpenMyGame.LoggerUnity.Messages.Factories
{
    internal interface ILogMessageFactory
    {
        LogMessage CreateMessage(LogLevel logLevel, int stacktraceDepth);
    }
}