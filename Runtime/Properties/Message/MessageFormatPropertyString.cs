using System;
using OpenMyGame.LoggerUnity.Runtime.Properties.Message.Base;

namespace OpenMyGame.LoggerUnity.Runtime.Properties.Message
{
    public class MessageFormatPropertyString : MessageFormatProperty<string>
    {
        protected override ReadOnlySpan<char> Render(string parameter, in ReadOnlySpan<char> format)
        {
            return parameter;
        }
    }
}