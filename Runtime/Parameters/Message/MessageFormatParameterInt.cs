using System;
using Openmygame.Logger.Configuration.Attributes;
using Openmygame.Logger.Infrastructure.StringBuilders;
using Openmygame.Logger.Parameters.Message.Base;

namespace Openmygame.Logger.Parameters.Message
{
    [Serializable]
    [SerializeReferenceDropdownName("Int")]
    internal class MessageFormatParameterInt : MessageFormatParameter<int>
    {
        protected override void Render(ref ValueStringBuilder destination, int parameter, in ReadOnlySpan<char> format)
        {
            destination.Append(parameter, format);
        }
    }
}