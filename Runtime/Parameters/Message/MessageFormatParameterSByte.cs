using System;
using OpenMyGame.LoggerUnity.Attributes;
using OpenMyGame.LoggerUnity.Parameters.Message.Base;
using SpanUtilities.StringBuilders;

namespace OpenMyGame.LoggerUnity.Parameters.Message
{
    [Serializable]
    [SerializeReferenceDropdownName("SByte")]
    internal class MessageFormatParameterSByte : MessageFormatParameter<sbyte>
    {
        protected override void Render(ref ValueStringBuilder destination, sbyte parameter, in ReadOnlySpan<char> format)
        {
            destination.Append(parameter, format);
        }
    }
}