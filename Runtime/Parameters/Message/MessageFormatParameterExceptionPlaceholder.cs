using System;
using Openmygame.Logger.Configuration.Attributes;
using Openmygame.Logger.Infrastructure.StringBuilders;
using Openmygame.Logger.Messages.Exceptions;
using Openmygame.Logger.Parameters.Message.Base;

namespace Openmygame.Logger.Parameters.Message
{
    [Serializable]
    [SerializeReferenceDropdownName("ExceptionPlaceholder")]
    internal class MessageFormatParameterExceptionPlaceholder : MessageFormatParameter<LogExceptionPlaceholder>
    {
        protected override void Render(ref ValueStringBuilder destination, LogExceptionPlaceholder parameter, in ReadOnlySpan<char> format)
        {
            destination.Append(parameter.Placeholder);
        }
    }
}