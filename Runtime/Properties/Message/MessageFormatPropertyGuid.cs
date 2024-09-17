using System;
using OpenMyGame.LoggerUnity.Runtime.Properties.Message.Base;

namespace OpenMyGame.LoggerUnity.Runtime.Properties.Message
{
    internal class MessageFormatPropertyGuid : MessageFormatProperty<Guid>
    {
        protected override ReadOnlySpan<char> Render(Guid parameter, in ReadOnlySpan<char> format)
        {
            if (format.IsEmpty)
            {
                return parameter.ToString();
            }

            return parameter.ToString(format.ToString());
        }
    }
}