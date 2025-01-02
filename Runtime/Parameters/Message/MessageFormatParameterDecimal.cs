using System;
using Openmygame.Logger.Configuration.Attributes;
using Openmygame.Logger.Infrastructure.StringBuilders;
using Openmygame.Logger.Parameters.Message.Base;

namespace Openmygame.Logger.Parameters.Message
{
    [Serializable]
    [SerializeReferenceDropdownName("Decimal")]
    internal class MessageFormatParameterDecimal : MessageFormatParameter<decimal>
    {
        protected override void Render(ref ValueStringBuilder destination, decimal parameter, in ReadOnlySpan<char> format)
        {
            destination.Append(parameter, format);
        }
    }
}