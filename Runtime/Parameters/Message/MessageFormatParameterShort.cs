using System;
using Openmygame.Logger.Configuration.Attributes;
using Openmygame.Logger.Infrastructure.StringBuilders;
using Openmygame.Logger.Parameters.Message.Base;

namespace Openmygame.Logger.Parameters.Message
{
    [Serializable]
    [SerializeReferenceDropdownName("Short")]
    internal class MessageFormatParameterShort : MessageFormatParameter<short>
    {
        protected override void Render(ref ValueStringBuilder destination, short parameter, in ReadOnlySpan<char> format)
        {
            destination.Append(parameter, format);
        }
    }
}