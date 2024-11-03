using System;
using OpenMyGame.LoggerUnity.Attributes;
using OpenMyGame.LoggerUnity.Extensions;
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
            if (message.Exception is null)
            {
                return;
            }
            
            destination.Append(message.Exception.ToStringNoStacktrace());
        }
    }
}