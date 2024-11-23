using System;
using OpenMyGame.LoggerUnity.Configuration.Attributes;
using OpenMyGame.LoggerUnity.Infrastructure.StringBuilders;
using OpenMyGame.LoggerUnity.Parameters.Message.Base;

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