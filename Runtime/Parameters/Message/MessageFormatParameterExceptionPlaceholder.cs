using System;
using OpenMyGame.LoggerUnity.Configuration.Attributes;
using OpenMyGame.LoggerUnity.Infrastructure.StringBuilders;
using OpenMyGame.LoggerUnity.Messages.Exceptions;
using OpenMyGame.LoggerUnity.Parameters.Message.Base;

namespace OpenMyGame.LoggerUnity.Parameters.Message
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