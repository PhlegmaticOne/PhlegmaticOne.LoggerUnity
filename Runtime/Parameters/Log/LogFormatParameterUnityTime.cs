using System;
using Openmygame.Logger.Configuration.Attributes;
using Openmygame.Logger.Infrastructure.StringBuilders;
using Openmygame.Logger.Messages;
using Openmygame.Logger.Parameters.Log.Base;
using Openmygame.Logger.Parsing.Models;
using UnityEngine;

namespace Openmygame.Logger.Parameters.Log
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