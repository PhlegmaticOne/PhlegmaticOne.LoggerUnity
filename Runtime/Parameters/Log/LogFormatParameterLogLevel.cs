using System;
using OpenMyGame.LoggerUnity.Attributes;
using OpenMyGame.LoggerUnity.Messages;
using OpenMyGame.LoggerUnity.Parameters.Log.Base;
using OpenMyGame.LoggerUnity.Parsing.Models;
using SpanUtilities.StringBuilders;

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

        public void Render(
            ref ValueStringBuilder destination, ref ValueStringBuilder renderedMessage, in MessagePart messagePart, in LogMessage message)
        {
            destination.Append(message.LogLevel.ToString());
        }
    }
}