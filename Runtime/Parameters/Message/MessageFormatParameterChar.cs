using System;
using OpenMyGame.LoggerUnity.Attributes;
using OpenMyGame.LoggerUnity.Infrastructure.StringBuilders;
using OpenMyGame.LoggerUnity.Parameters.Message.Base;

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