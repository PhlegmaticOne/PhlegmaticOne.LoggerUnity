using System;
using Openmygame.Logger.Configuration.Attributes;
using Openmygame.Logger.Infrastructure.StringBuilders;
using Openmygame.Logger.Parameters.Message.Base;

namespace Openmygame.Logger.Parameters.Message
{
    [Serializable]
    [SerializeReferenceDropdownName("UInt")]
    internal class MessageFormatParameterUInt : MessageFormatParameter<uint>
    {
        protected override void Render(ref ValueStringBuilder destination, uint parameter, in ReadOnlySpan<char> format)
        {
            destination.Append(parameter, format);
        }
    }
}