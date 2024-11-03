using System;
using OpenMyGame.LoggerUnity.Attributes;
using OpenMyGame.LoggerUnity.Infrastructure.StringBuilders;
using OpenMyGame.LoggerUnity.Parameters.Message.Base;

namespace OpenMyGame.LoggerUnity.Parameters.Message
{
    [Serializable]
    [SerializeReferenceDropdownName("Float")]
    internal class MessageFormatParameterFloat : MessageFormatParameter<float>
    {
        protected override void Render(ref ValueStringBuilder destination, float parameter, in ReadOnlySpan<char> format)
        {
            destination.Append(parameter, format);
        }
    }
}