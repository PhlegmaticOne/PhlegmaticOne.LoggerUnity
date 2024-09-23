using System;
using OpenMyGame.LoggerUnity.Properties.Message.Base;

namespace OpenMyGame.LoggerUnity.Properties.Message
{
    internal class MessageFormatPropertyTimeSpan : MessageFormatProperty<TimeSpan>
    {
        protected override ReadOnlySpan<char> Render(TimeSpan parameter, in ReadOnlySpan<char> format)
        {
            if (format.IsEmpty)
            {
                return parameter.ToString("g");
            }

            return parameter.ToString(format.ToString());
        }
    }
}