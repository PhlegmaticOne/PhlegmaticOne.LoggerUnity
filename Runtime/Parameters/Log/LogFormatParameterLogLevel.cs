using System;
using OpenMyGame.LoggerUnity.Configuration.Attributes;
using OpenMyGame.LoggerUnity.Extensions;
using OpenMyGame.LoggerUnity.Infrastructure.StringBuilders;
using OpenMyGame.LoggerUnity.Messages;
using OpenMyGame.LoggerUnity.Parameters.Log.Base;
using OpenMyGame.LoggerUnity.Parsing.Models;

namespace OpenMyGame.LoggerUnity.Parameters.Log
{
    [Serializable]
    [SerializeReferenceDropdownName(KeyParameter)]
    internal class LogFormatParameterLogLevel : ILogFormatParameter
    {
        public const string KeyParameter = "LogLevel";
        public string Key => KeyParameter;

        public object GetValue(in LogMessage message)
        {
            return message.LogLevel;
        }

        public void Render(ref ValueStringBuilder destination, in MessagePart messagePart, in LogMessage message)
        {
            destination.Append(message.LogLevel.ToStringCache());
        }
    }
}