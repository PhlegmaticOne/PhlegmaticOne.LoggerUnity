﻿using System.Collections.Concurrent;
using Openmygame.Logger.Infrastructure.StringBuilders;
using UnityEngine;

namespace Openmygame.Logger.Destinations.UnityDebug.Extensions
{
    internal static class ValueStringBuilderExtensions
    {
        private static readonly ConcurrentDictionary<Color, string> ColorsMap = new();
        
        public static void AppendColorPrefix(this ref ValueStringBuilder stringBuilder, in Color color)
        {
            var colorString = ColorsMap.GetOrAdd(color, ColorUtility.ToHtmlStringRGB);
            
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