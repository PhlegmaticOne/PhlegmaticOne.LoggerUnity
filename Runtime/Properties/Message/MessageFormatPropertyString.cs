using System;
using OpenMyGame.LoggerUnity.Properties.Message.Base;

namespace OpenMyGame.LoggerUnity.Properties.Message
{
    internal class MessageFormatPropertyString : MessageFormatProperty<string>
    {
        protected override ReadOnlySpan<char> Render(string parameter, in ReadOnlySpan<char> format)
        {
            return parameter;
        }
    }
}