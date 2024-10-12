using System;
using OpenMyGame.LoggerUnity.Attributes;
using OpenMyGame.LoggerUnity.Parameters.Message.Base;

namespace OpenMyGame.LoggerUnity.Parameters.Message
{
    [SerializeReferenceDropdownName("TimeSpan")]
    internal class MessageFormatParameterTimeSpan : MessageFormatParameter<TimeSpan>
    {
        protected override ReadOnlySpan<char> Render(TimeSpan parameter, in ReadOnlySpan<char> format)
        {
            if (format.IsEmpty)
            {
                return parameter.ToString();
            }

            return parameter.ToString(format.ToString());
        }
    }
}