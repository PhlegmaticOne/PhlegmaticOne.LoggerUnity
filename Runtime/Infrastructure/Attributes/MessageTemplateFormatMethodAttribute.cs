﻿using System;

namespace Openmygame.Logger.Infrastructure.Attributes
{
    [AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Method)]
    internal sealed class MessageTemplateFormatMethodAttribute : Attribute
    {
        public MessageTemplateFormatMethodAttribute(string messageTemplateParameterName)
        {
            MessageTemplateParameterName = messageTemplateParameterName;
        }

        public string MessageTemplateParameterName { get; private set; }
    }
}