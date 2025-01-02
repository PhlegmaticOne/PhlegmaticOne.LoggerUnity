using System;
using Openmygame.Logger.Configuration.Attributes;
using Openmygame.Logger.Infrastructure.StringBuilders;
using Openmygame.Logger.Parameters.Message.Base;

namespace Openmygame.Logger.Parameters.Message
{
    [Serializable]
    [SerializeReferenceDropdownName("Bool")]
    internal class MessageFormatParameterBool : MessageFormatParameter<bool>
    {
        protected override void Render(ref ValueStringBuilder destination, bool parameter, in ReadOnlySpan<char> format)
        {
            destination.Append(parameter);
        }
    }
}