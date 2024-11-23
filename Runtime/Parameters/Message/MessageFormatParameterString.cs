using System;
using OpenMyGame.LoggerUnity.Configuration.Attributes;
using OpenMyGame.LoggerUnity.Infrastructure.StringBuilders;
using OpenMyGame.LoggerUnity.Parameters.Message.Base;

namespace OpenMyGame.LoggerUnity.Parameters.Message
{
    [Serializable]
    [SerializeReferenceDropdownName("String")]
    internal class MessageFormatParameterString : MessageFormatParameter<string>
    {
        protected override void Render(ref ValueStringBuilder destination, string parameter, in ReadOnlySpan<char> format)
        {
            if (format.Equals("u", StringComparison.OrdinalIgnoreCase))
            {
                destination.Append(parameter.ToUpper());
                return;
            }
            
            if (format.Equals("l", StringComparison.OrdinalIgnoreCase))
            {
                destination.Append(parameter.ToLower());
                return;
            }
            
            destination.Append(parameter);
        }
    }
}