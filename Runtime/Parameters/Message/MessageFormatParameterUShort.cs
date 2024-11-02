using System;
using OpenMyGame.LoggerUnity.Attributes;
using OpenMyGame.LoggerUnity.Parameters.Message.Base;
using SpanUtilities.StringBuilders;

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