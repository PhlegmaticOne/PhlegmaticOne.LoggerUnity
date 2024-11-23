using System;
using OpenMyGame.LoggerUnity.Configuration.Attributes;
using OpenMyGame.LoggerUnity.Infrastructure.StringBuilders;
using OpenMyGame.LoggerUnity.Parameters.Message.Base;

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