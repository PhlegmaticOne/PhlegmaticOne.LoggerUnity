using System;
using Openmygame.Logger.Configuration.Attributes;
using Openmygame.Logger.Infrastructure.StringBuilders;
using Openmygame.Logger.Parameters.Message.Base;

namespace Openmygame.Logger.Parameters.Message
{
    [Serializable]
    [SerializeReferenceDropdownName("DateTime")]
    internal class MessageFormatParameterDateTime : MessageFormatParameter<DateTime>
    {
        protected override void Render(ref ValueStringBuilder destination, DateTime parameter, in ReadOnlySpan<char> format)
        {
            destination.Append(parameter, format);
        }
    }
}