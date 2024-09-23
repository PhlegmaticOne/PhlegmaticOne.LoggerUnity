using System;
using System.Linq;
using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Parsing.Models;
using OpenMyGame.LoggerUnity.Properties.Log.Base;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.Properties.Log
{
    internal class LogFormatPropertyUnityTime : ILogFormatProperty
    {
        private const string Format3 = "ticks";
        
        private static readonly char[] KnownFormats = { 'c', 'g', 'G' };

        public string Key => "UnityTime";
        
        public ReadOnlySpan<char> GetValue(in MessagePart messagePart, LogMessage message, in Span<object> parameters)
        {
            if (messagePart.TryGetFormat(out var format))
            {
                var time = TimeSpan.FromSeconds(Time.realtimeSinceStartup);
                return FormatTime(time, format);
            }

            return Time.realtimeSinceStartup.ToString("F");
        }

        internal static ReadOnlySpan<char> FormatTime(in TimeSpan timeSpan, in ReadOnlySpan<char> format)
        {
            if (format.Equals(Format3, StringComparison.OrdinalIgnoreCase))
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