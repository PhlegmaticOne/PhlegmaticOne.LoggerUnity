using System;
using OpenMyGame.LoggerUnity.Attributes;
using OpenMyGame.LoggerUnity.Parameters.Message.Base;
using SpanUtilities.StringBuilders;

namespace OpenMyGame.LoggerUnity.Parameters.Message
{
    [Serializable]
    [SerializeReferenceDropdownName("Char")]
    internal class MessageFormatParameterChar : MessageFormatParameter<char>
    {
        protected override void Render(ref ValueStringBuilder destination, char parameter, in ReadOnlySpan<char> format)
        {
            destination.Append(parameter);
        }
    }
}