using System;
using OpenMyGame.LoggerUnity.Configuration.Attributes;
using OpenMyGame.LoggerUnity.Infrastructure.StringBuilders;
using OpenMyGame.LoggerUnity.Parameters.Message.Base;

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