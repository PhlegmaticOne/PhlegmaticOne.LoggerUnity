using System;
using OpenMyGame.LoggerUnity.Attributes;
using OpenMyGame.LoggerUnity.Parameters.Message.Base;
using SpanUtilities.StringBuilders;

namespace OpenMyGame.LoggerUnity.Parameters.Message
{
    [Serializable]
    [SerializeReferenceDropdownName("Int")]
    internal class MessageFormatParameterInt : MessageFormatParameter<int>
    {
        protected override void Render(ref ValueStringBuilder destination, int parameter, in ReadOnlySpan<char> format)
        {
            destination.Append(parameter, format);
        }
    }
}