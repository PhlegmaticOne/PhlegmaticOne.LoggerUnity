using System;
using Openmygame.Logger.Configuration.Attributes;
using Openmygame.Logger.Infrastructure.StringBuilders;
using Openmygame.Logger.Parameters.Message.Base;

namespace Openmygame.Logger.Parameters.Message
{
    [Serializable]
    [SerializeReferenceDropdownName("Byte")]
    internal class MessageFormatParameterByte : MessageFormatParameter<byte>
    {
        protected override void Render(ref ValueStringBuilder destination, byte parameter, in ReadOnlySpan<char> format)
        {
            destination.Append(parameter, format);
        }
    }
}