using System;
using OpenMyGame.LoggerUnity.Runtime.Properties.Message.Base;

namespace OpenMyGame.LoggerUnity.Runtime.Properties.Message
{
    internal class MessageFormatPropertyDateTime : MessageFormatProperty<DateTime>
    {
        protected override ReadOnlySpan<char> Render(DateTime parameter, in ReadOnlySpan<char> format)
        {
            if (format.IsEmpty)
            {
                return parameter.ToString("G");
            }
            
            return parameter.ToString(format.ToString());
        }
    }
}