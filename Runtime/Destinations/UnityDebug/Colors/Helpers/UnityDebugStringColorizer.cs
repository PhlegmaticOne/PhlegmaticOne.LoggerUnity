using System;
using System.Text;
using OpenMyGame.LoggerUnity.Extensions;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.Destinations.UnityDebug.Colors.Helpers
{
    internal static class UnityDebugStringColorizer
    {
        private const int ColorWrapLength = 23;

        public static string ColorizeString(string value, in Color color)
        {
            var colorString = ColorUtility.ToHtmlStringRGB(color);
            return $"<color=#{colorString}>{value}</color>";
        }
        
        public static void ColorizeNonHeapAlloc(StringBuilder destination, in ReadOnlySpan<char> renderedValue, in Color color)
        {
            var offset = 0;
            var colorString = ColorUtility.ToHtmlStringRGB(color);
            
            Span<char> result = stackalloc char[renderedValue.Length + ColorWrapLength];

            result.FillString("<color=#", ref offset);
            result.FillString(colorString, ref offset);
            result.FillChar('>', ref offset);
            result.FillSpan(renderedValue, ref offset);
            result.FillString("</color>", ref offset);

            destination.Append(result);
        }
    }
}