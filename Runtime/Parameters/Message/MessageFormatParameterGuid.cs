using System;
using OpenMyGame.LoggerUnity.Configuration.Attributes;
using OpenMyGame.LoggerUnity.Infrastructure.StringBuilders;
using OpenMyGame.LoggerUnity.Parameters.Message.Base;

namespace OpenMyGame.LoggerUnity.Parameters.Message
{
    [Serializable]
    [SerializeReferenceDropdownName("Guid")]
    internal class MessageFormatParameterGuid : MessageFormatParameter<Guid>
    {
        protected override void Render(ref ValueStringBuilder destination, Guid parameter, in ReadOnlySpan<char> format)
        {
            destination.Append(parameter, format);
        }
    }
}