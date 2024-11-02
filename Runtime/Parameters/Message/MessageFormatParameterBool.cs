using System;
using OpenMyGame.LoggerUnity.Attributes;
using OpenMyGame.LoggerUnity.Parameters.Message.Base;
using SpanUtilities.StringBuilders;

namespace OpenMyGame.LoggerUnity.Parameters.Message
{
    [Serializable]
    [SerializeReferenceDropdownName("Bool")]
    internal class MessageFormatParameterBool : MessageFormatParameter<bool>
    {
        protected override void Render(ref ValueStringBuilder destination, bool parameter, in ReadOnlySpan<char> format)
        {
            destination.Append(parameter);
        }
    }
}