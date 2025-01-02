using System;
using Openmygame.Logger.Infrastructure.StringBuilders;
using Openmygame.Logger.Parsing.Models;

namespace Openmygame.Logger.Formats.Message
{
    public interface IMessageFormat
    {
        void Render(ref ValueStringBuilder destination, MessagePart[] messageParts, Span<object> parameters);
    }
}