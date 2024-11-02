using System;
using OpenMyGame.LoggerUnity.Attributes;
using OpenMyGame.LoggerUnity.Parameters.Message.Base;
using SpanUtilities.StringBuilders;

namespace OpenMyGame.LoggerUnity.Parameters.Message
{
    [Serializable]
    [SerializeReferenceDropdownName("DateTime")]
    internal class MessageFormatParameterDateTime : MessageFormatParameter<DateTime>
    {
        protected override void Render(ref ValueStringBuilder destination, DateTime parameter, in ReadOnlySpan<char> format)
        {
            destination.Append(parameter, format);
        }
    }
}