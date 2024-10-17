using System;
using OpenMyGame.LoggerUnity.Attributes;
using OpenMyGame.LoggerUnity.Messages;
using OpenMyGame.LoggerUnity.Parameters.Log.Base;
using OpenMyGame.LoggerUnity.Parsing.Models;

namespace OpenMyGame.LoggerUnity.Parameters.Log
{
    [Serializable]
    [SerializeReferenceDropdownName(KeyParameter)]
    internal class LogFormatParameterNewLine : ILogFormatParameter
    {
        public const string KeyParameter = "NewLine";
        public string Key => KeyParameter;
        
        public ReadOnlySpan<char> GetValue(MessagePart messagePart, in LogMessage message, string renderedMessage)
        {
            return Environment.NewLine;
        }
    }
}