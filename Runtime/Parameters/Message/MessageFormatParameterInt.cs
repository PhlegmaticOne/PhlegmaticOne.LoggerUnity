using System;
using OpenMyGame.LoggerUnity.Configuration.Attributes;
using OpenMyGame.LoggerUnity.Infrastructure.StringBuilders;
using OpenMyGame.LoggerUnity.Parameters.Message.Base;

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