using System;
using Openmygame.Logger.Configuration.Attributes;
using Openmygame.Logger.Infrastructure.StringBuilders;
using Openmygame.Logger.Parameters.Message.Base;

namespace Openmygame.Logger.Parameters.Message
{
    [Serializable]
    [SerializeReferenceDropdownName("Double")]
    internal class MessageFormatParameterDouble : MessageFormatParameter<double>
    {
        protected override void Render(ref ValueStringBuilder destination, double parameter, in ReadOnlySpan<char> format)
        {
            destination.Append(parameter, format);
        }
    }
}