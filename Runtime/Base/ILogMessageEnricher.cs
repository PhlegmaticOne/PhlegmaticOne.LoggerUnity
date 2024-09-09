using OpenMyGame.LoggerUnity.Runtime.Messages;

namespace OpenMyGame.LoggerUnity.Runtime.Base
{
    public interface ILogMessageEnricher
    {
        void Enrich(LogMessage message);
    }
}