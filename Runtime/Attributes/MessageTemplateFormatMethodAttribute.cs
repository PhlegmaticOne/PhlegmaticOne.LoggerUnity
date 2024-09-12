using System;

namespace OpenMyGame.LoggerUnity.Runtime.Attributes
{
    [AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Method)]
    public sealed class MessageTemplateFormatMethodAttribute : Attribute
    {
        public MessageTemplateFormatMethodAttribute(string messageTemplateParameterName)
        {
            MessageTemplateParameterName = messageTemplateParameterName;
        }

        public string MessageTemplateParameterName { get; private set; }
    }
}