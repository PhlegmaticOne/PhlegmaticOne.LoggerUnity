using System;
using OpenMyGame.LoggerUnity.Attributes;
using OpenMyGame.LoggerUnity.Infrastructure.StringBuilders;
using OpenMyGame.LoggerUnity.Parameters.Message.Base;

namespace OpenMyGame.LoggerUnity.Parameters.Message
{
    [Serializable]
    [SerializeReferenceDropdownName("UShort")]
    internal class MessageFormatParameterUShort : MessageFormatParameter<ushort>
    {
        protected override void Render(ref ValueStringBuilder destination, ushort parameter, in ReadOnlySpan<char> format)
        {
            destination.Append(parameter, format);
        }
    }
}