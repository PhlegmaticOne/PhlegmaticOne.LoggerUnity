using System;
using OpenMyGame.LoggerUnity.Configuration.Attributes;
using OpenMyGame.LoggerUnity.Infrastructure.StringBuilders;
using OpenMyGame.LoggerUnity.Messages;
using OpenMyGame.LoggerUnity.Parameters.Log.Base;
using OpenMyGame.LoggerUnity.Parsing.Models;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.Parameters.Log
{
    [Serializable]
    [SerializeReferenceDropdownName(KeyParameter)]
    internal class LogFormatParameterUnityTime : ILogFormatParameter
    {
        public const string KeyParameter = "UnityTime";

        public string Key => KeyParameter;

        public void Render(ref ValueStringBuilder destination, in MessagePart messagePart, in LogMessage message)
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