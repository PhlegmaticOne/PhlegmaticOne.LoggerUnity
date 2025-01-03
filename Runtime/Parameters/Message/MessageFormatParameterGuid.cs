﻿using System;
using Openmygame.Logger.Configuration.Attributes;
using Openmygame.Logger.Infrastructure.StringBuilders;
using Openmygame.Logger.Parameters.Message.Base;

namespace Openmygame.Logger.Parameters.Message
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