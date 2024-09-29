using System;
using OpenMyGame.LoggerUnity.Parameters.Message.Base;

namespace OpenMyGame.LoggerUnity.Parameters.Message
{
    internal class MessageFormatParameterDateTime : MessageFormatParameter<DateTime>
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