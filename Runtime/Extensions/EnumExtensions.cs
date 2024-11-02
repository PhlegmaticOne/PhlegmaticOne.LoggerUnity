using System;
using System.Collections.Generic;

namespace OpenMyGame.LoggerUnity.Extensions
{
    internal static class EnumExtensions
    {
        private static readonly Dictionary<Enum, string> Cache = new();

        public static string ToStringCache(this Enum @enum)
        {
            if (Cache.TryGetValue(@enum, out var cache))
            {
                return cache;
            }

            var value = @enum.ToString();
            Cache[@enum] = value;
            return value;
        }
    }
}