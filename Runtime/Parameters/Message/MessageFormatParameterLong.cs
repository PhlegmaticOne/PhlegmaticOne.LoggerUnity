using System;
using OpenMyGame.LoggerUnity.Attributes;
using OpenMyGame.LoggerUnity.Infrastructure.StringBuilders;
using OpenMyGame.LoggerUnity.Parameters.Message.Base;

namespace OpenMyGame.LoggerUnity.Parameters.Message
{
    [Serializable]
    [SerializeReferenceDropdownName("Long")]
    internal class MessageFormatParameterLong : MessageFormatParameter<long>
    {
        protected override void Render(ref ValueStringBuilder destination, long parameter, in ReadOnlySpan<char> format)
        {
            destination.Append(parameter, format);
        }
    }
}