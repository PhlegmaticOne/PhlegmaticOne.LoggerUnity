using UnityEngine;

namespace OpenMyGame.LoggerUnity.Extensions
{
    internal static class StringExtensions
    {
        public static string Colorize(this string value, in Color color)
        {
            var colorString = ColorUtility.ToHtmlStringRGB(color);
            return $"<color=#{colorString}>{value}</color>";
        }
        
        public static (int, int) CountBraces(this string value)
        {
            var countOpenBraces = 0;
            var countCloseBraces = 0;

            for (var i = 0; i < value.Length; i++)
            {
                var item = value[i];

                switch (item)
                {
                    case '{':
                        countOpenBraces++;
                        break;
                    case '}':
                        countCloseBraces++;
                        break;
                }
            }

            return (countOpenBraces, countCloseBraces);
        }
    }
}