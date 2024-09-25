using System;
using OpenMyGame.LoggerUnity.Properties.Message.Base;

namespace OpenMyGame.LoggerUnity.Properties.Message
{
    internal class MessageFormatPropertyString : MessageFormatProperty<string>
    {
        protected override ReadOnlySpan<char> Render(string parameter, in ReadOnlySpan<char> format)
        {
            if (format.Equals("u", StringComparison.OrdinalIgnoreCase))
            {
                return parameter.ToUpper();
            }

            if (format.Equals("l", StringComparison.OrdinalIgnoreCase))
            {
                return parameter.ToLower();
            }
            
            return parameter;
        }
    }
}