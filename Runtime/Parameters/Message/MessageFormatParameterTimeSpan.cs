using System;
using OpenMyGame.LoggerUnity.Parameters.Message.Base;

namespace OpenMyGame.LoggerUnity.Parameters.Message
{
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