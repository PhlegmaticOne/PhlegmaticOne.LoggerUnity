using System;
using OpenMyGame.LoggerUnity.Attributes;
using OpenMyGame.LoggerUnity.Parameters.Message.Base;
using SpanUtilities.StringBuilders;

namespace OpenMyGame.LoggerUnity.Parameters.Message
{
    [Serializable]
    [SerializeReferenceDropdownName("TimeSpan")]
    internal class MessageFormatParameterTimeSpan : MessageFormatParameter<TimeSpan>
    {
        protected override void Render(ref ValueStringBuilder destination, TimeSpan parameter, in ReadOnlySpan<char> format)
        {
            destination.Append(parameter, format);
        }
    }
}