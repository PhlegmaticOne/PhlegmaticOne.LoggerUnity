using System;
using OpenMyGame.LoggerUnity.Configuration.Attributes;
using OpenMyGame.LoggerUnity.Infrastructure.StringBuilders;
using OpenMyGame.LoggerUnity.Parameters.Message.Base;

namespace OpenMyGame.LoggerUnity.Parameters.Message
{
    [Serializable]
    [SerializeReferenceDropdownName("DateTime")]
    internal class MessageFormatParameterDateTime : MessageFormatParameter<DateTime>
    {
        protected override void Render(ref ValueStringBuilder destination, DateTime parameter, in ReadOnlySpan<char> format)
        {
            destination.Append(parameter, format);
        }
    }
}