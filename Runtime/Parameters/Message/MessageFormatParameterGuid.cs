using System;
using OpenMyGame.LoggerUnity.Attributes;
using OpenMyGame.LoggerUnity.Parameters.Message.Base;
using SpanUtilities.StringBuilders;

namespace OpenMyGame.LoggerUnity.Parameters.Message
{
    [Serializable]
    [SerializeReferenceDropdownName("Guid")]
    internal class MessageFormatParameterGuid : MessageFormatParameter<Guid>
    {
        protected override void Render(ref ValueStringBuilder destination, Guid parameter, in ReadOnlySpan<char> format)
        {
            destination.Append(parameter, format);
        }
    }
}