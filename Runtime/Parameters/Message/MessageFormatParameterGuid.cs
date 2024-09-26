using System;
using OpenMyGame.LoggerUnity.Parameters.Message.Base;

namespace OpenMyGame.LoggerUnity.Parameters.Message
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