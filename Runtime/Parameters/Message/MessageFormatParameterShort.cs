using System;
using OpenMyGame.LoggerUnity.Attributes;
using OpenMyGame.LoggerUnity.Parameters.Message.Base;
using SpanUtilities.StringBuilders;

namespace OpenMyGame.LoggerUnity.Parameters.Message
{
    [Serializable]
    [SerializeReferenceDropdownName("Short")]
    internal class MessageFormatParameterShort : MessageFormatParameter<short>
    {
        protected override void Render(ref ValueStringBuilder destination, short parameter, in ReadOnlySpan<char> format)
        {
            destination.Append(parameter, format);
        }
    }
}