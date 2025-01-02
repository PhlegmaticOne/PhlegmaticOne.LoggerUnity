using Openmygame.Logger.Parsing.Models;

namespace Openmygame.Logger.Parsing.Base
{
    public interface IMessageFormatParser
    {
        MessagePart[] Parse(string format);
    }
}