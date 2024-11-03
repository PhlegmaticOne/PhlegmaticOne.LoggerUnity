using System;
using OpenMyGame.LoggerUnity.Attributes;
using OpenMyGame.LoggerUnity.Infrastructure.StringBuilders;
using OpenMyGame.LoggerUnity.Messages;
using OpenMyGame.LoggerUnity.Parameters.Log.Base;
using OpenMyGame.LoggerUnity.Parsing.Models;

namespace OpenMyGame.LoggerUnity.Parameters.Log
{
    [Serializable]
    [SerializeReferenceDropdownName(KeyParameter)]
    internal class LogFormatParameterException : ILogFormatParameter
    {
        public const string KeyParameter = "Exception";
        public string Key => KeyParameter;

        public bool IsEmpty(in LogMessage message)
        {
            return message.Exception is null;
        }

        public void Render(ref ValueStringBuilder destination, in MessagePart messagePart, in LogMessage message)
        {
            RenderException(ref destination, message.Exception);
        }
        
        private static void RenderException(ref ValueStringBuilder stringBuilder, Exception exception)
        {
            var exceptionClassName = exception.GetType().Name;
            var message = exception.Message;

            stringBuilder.Append(exceptionClassName);

            if (message is { Length: > 0 })
            {
                stringBuilder.Append(": ");
                stringBuilder.Append(message);
            }
            
            if (exception.InnerException != null)
            {
                stringBuilder.Append(" ---> ");
                stringBuilder.Append(exception.InnerException.ToString());
            }
        }
    }
}