using System;
using OpenMyGame.LoggerUnity.Attributes;
using OpenMyGame.LoggerUnity.Messages;
using OpenMyGame.LoggerUnity.Parameters.Log.Base;
using OpenMyGame.LoggerUnity.Parsing.Models;
using SpanUtilities.StringBuilders;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.Parameters.Log
{
    [Serializable]
    [SerializeReferenceDropdownName(KeyParameter)]
    internal class LogFormatParameterUnityTime : ILogFormatParameter
    {
        public const string KeyParameter = "UnityTime";

        public string Key => KeyParameter;

        public void Render(ref ValueStringBuilder destination, ref ValueStringBuilder renderedMessage, in MessagePart messagePart,
            in LogMessage message)
        {
            if (messagePart.TryGetFormat(out var format))
            {
                var time = TimeSpan.FromSeconds(Time.realtimeSinceStartup);
                destination.Append(time, format);
                return;
            }

            destination.Append(Time.realtimeSinceStartup, "F");
        }
    }
}