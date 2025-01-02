using System;
using Openmygame.Logger.Configuration.Attributes;
using Openmygame.Logger.Infrastructure.StringBuilders;
using Openmygame.Logger.Messages.Tagging;
using Openmygame.Logger.Parameters.Message.Base;

namespace Openmygame.Logger.Parameters.Message
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