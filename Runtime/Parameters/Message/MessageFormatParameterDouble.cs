using System;
using OpenMyGame.LoggerUnity.Attributes;
using OpenMyGame.LoggerUnity.Infrastructure.StringBuilders;
using OpenMyGame.LoggerUnity.Parameters.Message.Base;

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