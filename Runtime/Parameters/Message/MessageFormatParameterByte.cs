using System;
using OpenMyGame.LoggerUnity.Attributes;
using OpenMyGame.LoggerUnity.Parameters.Message.Base;
using SpanUtilities.StringBuilders;

namespace OpenMyGame.LoggerUnity.Parameters.Message
{
    [Serializable]
    [SerializeReferenceDropdownName("Byte")]
    internal class MessageFormatParameterByte : MessageFormatParameter<byte>
    {
        protected override void Render(ref ValueStringBuilder destination, byte parameter, in ReadOnlySpan<char> format)
        {
            destination.Append(parameter, format);
        }
    }
}