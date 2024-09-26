using System;
using OpenMyGame.LoggerUnity.Properties.Message.Base;

namespace OpenMyGame.LoggerUnity.Properties.Message
{
    internal class MessageFormatParameterGuid : MessageFormatParameter<Guid>
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