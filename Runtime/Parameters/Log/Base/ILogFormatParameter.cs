using Openmygame.Logger.Infrastructure.StringBuilders;
using Openmygame.Logger.Messages;
using Openmygame.Logger.Parsing.Models;

namespace Openmygame.Logger.Parameters.Log.Base
{
    public interface ILogFormatParameter
    {
        string Key { get; }

        bool IsEmpty(in LogMessage message) => false;
        object GetValue(in LogMessage message) => null;

        void Render(ref ValueStringBuilder destination, in MessagePart messagePart, in LogMessage message);
    }
}