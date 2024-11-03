using System.Threading;

namespace OpenMyGame.LoggerUnity.Messages.Factories
{
    internal class LogMessageFactory : ILogMessageFactory
    {
        private int _currentMessageId = -1;
        
        public LogMessage CreateMessage(LogLevel logLevel, int stacktraceDepth)
        {
            return new LogMessage(
                Interlocked.Increment(ref _currentMessageId), 
                stacktraceDepth,
                logLevel, 
                Log.Logger);
        }
    }
}