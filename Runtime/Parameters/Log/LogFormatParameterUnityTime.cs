using System;
using System.Linq;
using OpenMyGame.LoggerUnity.Attributes;
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
        private const string TicksFormat = "ticks";
        
        public const string KeyParameter = "UnityTime";

        private static readonly char[] KnownFormats = { 'c', 'g', 'G' };

        public string Key => KeyParameter;
        
        public ReadOnlySpan<char> GetValue(MessagePart messagePart, LogMessage message, string renderedMessage)
        {
            if (messagePart.TryGetFormat(out var format))
            {
                var time = TimeSpan.FromSeconds(Time.realtimeSinceStartup);
                return FormatTime(time, format);
            }

            return Time.realtimeSinceStartup.ToString("F");
        }

        private static ReadOnlySpan<char> FormatTime(in TimeSpan timeSpan, in ReadOnlySpan<char> format)
        {
            if (format.Equals(TicksFormat, StringComparison.OrdinalIgnoreCase))
            {
                return timeSpan.Ticks.ToString();
            }

            if (KnownFormats.Contains(format[0]))
            {
                return timeSpan.ToString(format[0].ToString());
            }

            return timeSpan.ToString("c");
        }
    }
}