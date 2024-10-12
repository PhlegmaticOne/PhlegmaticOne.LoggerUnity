using System;
using OpenMyGame.LoggerUnity.Attributes;
using OpenMyGame.LoggerUnity.Messages.Tagging;
using OpenMyGame.LoggerUnity.Parameters.Message.Base;

namespace OpenMyGame.LoggerUnity.Parameters.Message
{
    [SerializeReferenceDropdownName("Tag")]
    internal class MessageFormatParameterTag : MessageFormatParameter<LogTag>
    {
        protected override ReadOnlySpan<char> Render(LogTag parameter, in ReadOnlySpan<char> format)
        {
            return parameter.Value;
        }
    }
}