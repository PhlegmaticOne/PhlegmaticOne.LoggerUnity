using OpenMyGame.LoggerUnity.Runtime.Properties.Container;

namespace OpenMyGame.LoggerUnity.Runtime.Parsing
{
    public interface IMessageFormatParser
    {
        MessageFormat Parse(string format, ILogMessagePartRenderer messagePartRenderer);
    }
}