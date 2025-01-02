using System;
using Openmygame.Logger.Configuration.Attributes;
using Openmygame.Logger.Infrastructure.StringBuilders;
using Openmygame.Logger.Parameters.Message.Base;

namespace Openmygame.Logger.Parameters.Message
{
    [Serializable]
    [SerializeReferenceDropdownName("UShort")]
    internal class MessageFormatParameterUShort : MessageFormatParameter<ushort>
    {
        protected override void Render(ref ValueStringBuilder destination, ushort parameter, in ReadOnlySpan<char> format)
        {
            destination.Append(parameter, format);
        }
    }
}