using System;
using OpenMyGame.LoggerUnity.Attributes;
using OpenMyGame.LoggerUnity.Parameters.Message.Base;
using SpanUtilities.StringBuilders;

namespace OpenMyGame.LoggerUnity.Parameters.Message
{
    [Serializable]
    [SerializeReferenceDropdownName("ULong")]
    internal class MessageFormatParameterULong : MessageFormatParameter<ulong>
    {
        protected override void Render(ref ValueStringBuilder destination, ulong parameter, in ReadOnlySpan<char> format)
        {
            destination.Append(parameter, format);
        }
    }
}