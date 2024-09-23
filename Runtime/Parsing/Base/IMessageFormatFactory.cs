using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Parsing.Models;

namespace OpenMyGame.LoggerUnity.Parsing.Base
{
    public interface IMessageFormatFactory
    {
        IMessageFormat CreateFormat(MessagePart[] messageParts);
    }
}