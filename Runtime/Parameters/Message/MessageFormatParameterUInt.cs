using System;
using OpenMyGame.LoggerUnity.Attributes;
using OpenMyGame.LoggerUnity.Infrastructure.StringBuilders;
using OpenMyGame.LoggerUnity.Parameters.Message.Base;

namespace OpenMyGame.LoggerUnity.Parameters.Message
{
    [Serializable]
    [SerializeReferenceDropdownName("UInt")]
    internal class MessageFormatParameterUInt : MessageFormatParameter<uint>
    {
        protected override void Render(ref ValueStringBuilder destination, uint parameter, in ReadOnlySpan<char> format)
        {
            destination.Append(parameter, format);
        }
    }
}