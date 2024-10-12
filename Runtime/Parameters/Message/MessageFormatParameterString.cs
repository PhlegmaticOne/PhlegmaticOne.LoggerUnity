using System;
using OpenMyGame.LoggerUnity.Attributes;
using OpenMyGame.LoggerUnity.Parameters.Message.Base;

namespace OpenMyGame.LoggerUnity.Parameters.Message
{
    [SerializeReferenceDropdownName("String")]
    internal class MessageFormatParameterString : MessageFormatParameter<string>
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