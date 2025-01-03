using System;
using Openmygame.Logger.Configuration.Attributes;
using Openmygame.Logger.Infrastructure.StringBuilders;
using Openmygame.Logger.Messages.Tagging;
using Openmygame.Logger.Parameters.Message.Base;

namespace Openmygame.Logger.Parameters.Message
{
    [Serializable]
    [SerializeReferenceDropdownName("Tag")]
    internal class MessageFormatParameterTag : MessageFormatParameter<Tag>
    {
        protected override void Render(ref ValueStringBuilder destination, Tag parameter, in ReadOnlySpan<char> format)
        {
            var tagFormat = parameter.Format;
            destination.Append(tagFormat.Prefix);
            destination.Append(parameter.Value);
            destination.Append(tagFormat.Postfix);
        }
    }
}