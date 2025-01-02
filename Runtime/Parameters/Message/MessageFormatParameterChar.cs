using System;
using Openmygame.Logger.Configuration.Attributes;
using Openmygame.Logger.Infrastructure.StringBuilders;
using Openmygame.Logger.Parameters.Message.Base;

namespace Openmygame.Logger.Parameters.Message
{
    [Serializable]
    [SerializeReferenceDropdownName("Char")]
    internal class MessageFormatParameterChar : MessageFormatParameter<char>
    {
        protected override void Render(ref ValueStringBuilder destination, char parameter, in ReadOnlySpan<char> format)
        {
            destination.Append(parameter);
        }
    }
}