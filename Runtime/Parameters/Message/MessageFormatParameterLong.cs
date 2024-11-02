﻿using System;
using OpenMyGame.LoggerUnity.Attributes;
using OpenMyGame.LoggerUnity.Parameters.Message.Base;
using SpanUtilities.StringBuilders;

namespace OpenMyGame.LoggerUnity.Parameters.Message
{
    [Serializable]
    [SerializeReferenceDropdownName("Long")]
    internal class MessageFormatParameterLong : MessageFormatParameter<long>
    {
        protected override void Render(ref ValueStringBuilder destination, long parameter, in ReadOnlySpan<char> format)
        {
            destination.Append(parameter, format);
        }
    }
}