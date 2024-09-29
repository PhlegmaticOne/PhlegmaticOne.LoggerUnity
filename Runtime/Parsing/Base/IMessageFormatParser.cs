using OpenMyGame.LoggerUnity.Base;

namespace OpenMyGame.LoggerUnity.Parsing.Base
{
    public interface IMessageFormatParser
    {
        IMessageFormat Parse(string format);
    }
}