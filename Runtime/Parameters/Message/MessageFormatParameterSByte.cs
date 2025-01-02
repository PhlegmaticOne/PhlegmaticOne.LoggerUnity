using System;
using Openmygame.Logger.Configuration.Attributes;
using Openmygame.Logger.Infrastructure.StringBuilders;
using Openmygame.Logger.Parameters.Message.Base;

namespace Openmygame.Logger.Parameters.Message
{
    [Serializable]
    [SerializeReferenceDropdownName("SByte")]
    internal class MessageFormatParameterSByte : MessageFormatParameter<sbyte>
    {
        protected override void Render(ref ValueStringBuilder destination, sbyte parameter, in ReadOnlySpan<char> format)
        {
            destination.Append(parameter, format);
        }
    }
}