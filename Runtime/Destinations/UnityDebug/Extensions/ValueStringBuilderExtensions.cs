using SpanUtilities.StringBuilders;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.Destinations.UnityDebug.Extensions
{
    public static class ValueStringBuilderExtensions
    {
        public static void AppendColorPrefix(this ref ValueStringBuilder stringBuilder, in Color color)
        {
            var colorString = ColorUtility.ToHtmlStringRGB(color);
            
            stringBuilder.Append("<color=#");
            stringBuilder.Append(colorString);
            stringBuilder.Append('>');
        }

        public static void AppendColorPostfix(this ref ValueStringBuilder stringBuilder)
        {
            stringBuilder.Append("</color>");
        }
    }
}