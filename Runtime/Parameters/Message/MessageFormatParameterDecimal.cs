using System;
using OpenMyGame.LoggerUnity.Attributes;
using OpenMyGame.LoggerUnity.Parameters.Message.Base;
using SpanUtilities.StringBuilders;

namespace OpenMyGame.LoggerUnity.Parameters.Message
{
    [Serializable]
    [SerializeReferenceDropdownName("Decimal")]
    internal class MessageFormatParameterDecimal : MessageFormatParameter<decimal>
    {
        protected override void Render(ref ValueStringBuilder destination, decimal parameter, in ReadOnlySpan<char> format)
        {
            destination.Append(parameter, format);
        }
    }
}