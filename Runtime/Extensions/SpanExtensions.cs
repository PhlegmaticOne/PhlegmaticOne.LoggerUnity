using System;

namespace OpenMyGame.LoggerUnity.Extensions
{
    internal static class SpanExtensions
    {
        public static void ToUpperCase(this in Span<char> span)
        {
            for (var i = 0; i < span.Length; i++)
            {
                span[i] = char.ToUpper(span[i]);
            }
        }
        
        public static void ToLowerCase(this in Span<char> span)
        {
            for (var i = 0; i < span.Length; i++)
            {
                span[i] = char.ToLower(span[i]);
            }
        }
    }
}