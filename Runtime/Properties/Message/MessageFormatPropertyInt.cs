using System;
using OpenMyGame.LoggerUnity.Runtime.Properties.Message.Base;

namespace OpenMyGame.LoggerUnity.Runtime.Properties.Message
{
    public class MessageFormatPropertyInt : MessageFormatProperty<int>
    {
        protected override ReadOnlySpan<char> Render(int parameter, in ReadOnlySpan<char> format)
        {
            return parameter.ToString();
        }
    }
}