using System;
using Openmygame.Logger.Configuration.Attributes;
using Openmygame.Logger.Infrastructure.Extensions;
using Openmygame.Logger.Infrastructure.StringBuilders;
using Openmygame.Logger.Messages;
using Openmygame.Logger.Parameters.Log.Base;
using Openmygame.Logger.Parsing.Models;

namespace Openmygame.Logger.Parameters.Log
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