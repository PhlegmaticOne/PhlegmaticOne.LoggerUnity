using System;
using OpenMyGame.LoggerUnity.Attributes;
using OpenMyGame.LoggerUnity.Parameters.Message.Base;
using SpanUtilities.StringBuilders;

namespace OpenMyGame.LoggerUnity.Parameters.Message
{
    [Serializable]
    [SerializeReferenceDropdownName("Double")]
    internal class MessageFormatParameterDouble : MessageFormatParameter<double>
    {
        protected override void Render(ref ValueStringBuilder destination, double parameter, in ReadOnlySpan<char> format)
        {
            destination.Append(parameter, format);
        }
    }
}