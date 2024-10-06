using System;
using OpenMyGame.LoggerUnity.Messages.Tagging;
using OpenMyGame.LoggerUnity.Parameters.Message.Base;

namespace OpenMyGame.LoggerUnity.Parameters.Message
{
    internal class MessageFormatParameterTag : MessageFormatParameter<LogTag>
    {
        protected override ReadOnlySpan<char> Render(LogTag parameter, in ReadOnlySpan<char> format)
        {
            return parameter.Tag;
        }
    }
}