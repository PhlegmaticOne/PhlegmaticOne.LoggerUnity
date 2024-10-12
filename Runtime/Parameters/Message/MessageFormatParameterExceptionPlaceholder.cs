using System;
using OpenMyGame.LoggerUnity.Attributes;
using OpenMyGame.LoggerUnity.Messages.Exceptions;
using OpenMyGame.LoggerUnity.Parameters.Message.Base;

namespace OpenMyGame.LoggerUnity.Parameters.Message
{
    [SerializeReferenceDropdownName("ExceptionPlaceholder")]
    internal class MessageFormatParameterExceptionPlaceholder : MessageFormatParameter<LogExceptionPlaceholder>
    {
        protected override ReadOnlySpan<char> Render(LogExceptionPlaceholder parameter, in ReadOnlySpan<char> format)
        {
            return parameter.Placeholder;
        }
    }
}