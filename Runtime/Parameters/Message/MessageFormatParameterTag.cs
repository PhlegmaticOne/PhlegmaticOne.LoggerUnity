using System;
using OpenMyGame.LoggerUnity.Configuration.Attributes;
using OpenMyGame.LoggerUnity.Infrastructure.StringBuilders;
using OpenMyGame.LoggerUnity.Messages.Tagging;
using OpenMyGame.LoggerUnity.Parameters.Message.Base;

namespace OpenMyGame.LoggerUnity.Parameters.Message
{
    [Serializable]
    [SerializeReferenceDropdownName("Tag")]
    internal class MessageFormatParameterTag : MessageFormatParameter<LogTag>
    {
        protected override void Render(ref ValueStringBuilder destination, LogTag parameter, in ReadOnlySpan<char> format)
        {
            var tafFormat = parameter.Format;
            destination.Append(tafFormat.Prefix);
            destination.Append(parameter.Value);
            destination.Append(tafFormat.Postfix);
        }
    }
}