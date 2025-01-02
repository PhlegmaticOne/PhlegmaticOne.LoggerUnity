using System;
using Openmygame.Logger.Configuration.Attributes;
using Openmygame.Logger.Infrastructure.StringBuilders;
using Openmygame.Logger.Parameters.Message.Base;

namespace Openmygame.Logger.Parameters.Message
{
    [Serializable]
    [SerializeReferenceDropdownName("Float")]
    internal class MessageFormatParameterFloat : MessageFormatParameter<float>
    {
        protected override void Render(ref ValueStringBuilder destination, float parameter, in ReadOnlySpan<char> format)
        {
            destination.Append(parameter, format);
        }
    }
}