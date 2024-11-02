using System;
using OpenMyGame.LoggerUnity.Attributes;
using OpenMyGame.LoggerUnity.Messages.Tagging;
using OpenMyGame.LoggerUnity.Parameters.Message.Base;
using SpanUtilities.StringBuilders;

namespace OpenMyGame.LoggerUnity.Parameters.Message
{
    [Serializable]
    [SerializeReferenceDropdownName("Tag")]
    internal class MessageFormatParameterTag : MessageFormatParameter<LogTag>
    {
        protected override void Render(ref ValueStringBuilder destination, LogTag parameter, in ReadOnlySpan<char> format)
        {
            destination.Append(parameter.Value);
        }
    }
}