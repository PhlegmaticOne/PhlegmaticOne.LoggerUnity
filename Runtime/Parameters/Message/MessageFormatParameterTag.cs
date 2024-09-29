using System;
using OpenMyGame.LoggerUnity.Parameters.Message.Base;
using OpenMyGame.LoggerUnity.Tagging;

namespace OpenMyGame.LoggerUnity.Parameters.Message
{
    internal class MessageFormatParameterTag : MessageFormatParameter<LogTag>
    {
        protected override ReadOnlySpan<char> Render(LogTag parameter, in ReadOnlySpan<char> format)
        {
            if (format.IsEmpty || format[0] != 'c')
            {
                return parameter.Tag;
            }

            return parameter.Render();
        }
    }
}