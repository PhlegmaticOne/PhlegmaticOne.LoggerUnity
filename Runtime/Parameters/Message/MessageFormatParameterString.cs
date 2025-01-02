using System;
using Openmygame.Logger.Configuration.Attributes;
using Openmygame.Logger.Infrastructure.StringBuilders;
using Openmygame.Logger.Parameters.Message.Base;

namespace Openmygame.Logger.Parameters.Message
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