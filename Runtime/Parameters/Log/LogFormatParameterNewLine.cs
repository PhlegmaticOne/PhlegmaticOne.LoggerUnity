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
    internal class LogFormatParameterNewLine : ILogFormatParameter
    {
        public const string KeyParameter = "NewLine";
        public string Key => KeyParameter;

        public void Render(ref ValueStringBuilder destination, ref ValueStringBuilder renderedMessage,
            in MessagePart messagePart,
            in LogMessage message)
        {
            destination.AppendLine();
        }
    }
}