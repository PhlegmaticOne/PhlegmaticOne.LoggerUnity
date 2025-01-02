using System;
using Openmygame.Logger.Configuration.Attributes;
using Openmygame.Logger.Infrastructure.StringBuilders;
using Openmygame.Logger.Parameters.Message.Base;

namespace Openmygame.Logger.Parameters.Message
{
    [Serializable]
    [SerializeReferenceDropdownName("ULong")]
    internal class MessageFormatParameterULong : MessageFormatParameter<ulong>
    {
        protected override void Render(ref ValueStringBuilder destination, ulong parameter, in ReadOnlySpan<char> format)
        {
            destination.Append(parameter, format);
        }
    }
}