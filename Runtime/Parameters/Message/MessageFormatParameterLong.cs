using System;
using Openmygame.Logger.Configuration.Attributes;
using Openmygame.Logger.Infrastructure.StringBuilders;
using Openmygame.Logger.Parameters.Message.Base;

namespace Openmygame.Logger.Parameters.Message
{
    [Serializable]
    [SerializeReferenceDropdownName("Long")]
    internal class MessageFormatParameterLong : MessageFormatParameter<long>
    {
        protected override void Render(ref ValueStringBuilder destination, long parameter, in ReadOnlySpan<char> format)
        {
            destination.Append(parameter, format);
        }
    }
}