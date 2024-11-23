using System;
using OpenMyGame.LoggerUnity.Configuration.Attributes;
using OpenMyGame.LoggerUnity.Infrastructure.StringBuilders;
using OpenMyGame.LoggerUnity.Parameters.Message.Base;

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