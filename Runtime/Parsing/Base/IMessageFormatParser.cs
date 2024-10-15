using OpenMyGame.LoggerUnity.Parsing.Models;

namespace OpenMyGame.LoggerUnity.Parsing.Base
{
    public interface IMessageFormatParser
    {
        MessagePart[] Parse(string format);
    }
}