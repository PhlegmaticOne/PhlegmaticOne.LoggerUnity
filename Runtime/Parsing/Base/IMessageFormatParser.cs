using OpenMyGame.LoggerUnity.Runtime.Base;

namespace OpenMyGame.LoggerUnity.Runtime.Parsing.Base
{
    public interface IMessageFormatParser
    {
        IMessageFormat Parse(string format, ILogMessagePartRenderer messagePartRenderer);
    }
}