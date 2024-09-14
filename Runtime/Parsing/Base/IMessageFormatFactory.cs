using OpenMyGame.LoggerUnity.Runtime.Base;
using OpenMyGame.LoggerUnity.Runtime.Parsing.Models;

namespace OpenMyGame.LoggerUnity.Runtime.Parsing.Base
{
    public interface IMessageFormatFactory
    {
        IMessageFormat CreateFormat(MessagePart[] messageParts);
    }
}