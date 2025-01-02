using System;
using Openmygame.Logger.Configuration.Attributes;
using Openmygame.Logger.Infrastructure.StringBuilders;
using Openmygame.Logger.Parameters.Message.Base;

namespace Openmygame.Logger.Parameters.Message
{
    [Serializable]
    [SerializeReferenceDropdownName("TimeSpan")]
    internal class MessageFormatParameterTimeSpan : MessageFormatParameter<TimeSpan>
    {
        protected override void Render(ref ValueStringBuilder destination, TimeSpan parameter, in ReadOnlySpan<char> format)
        {
            destination.Append(parameter, format);
        }
    }
}