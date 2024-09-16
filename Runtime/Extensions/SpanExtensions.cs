using System;
using System.Runtime.InteropServices;

namespace OpenMyGame.LoggerUnity.Runtime.Extensions
{
    internal static class SpanExtensions
    {
        public static ReadOnlySpan<T> ToReadOnlySpan<T>(this in Span<T> span)
        {
            return MemoryMarshal.CreateReadOnlySpan(ref span[0], span.Length);
        }

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
        
        public static int CountOf<T>(this in ReadOnlySpan<T> span, T value) where T : IEquatable<T>
        {
            var count = 0;

            foreach (var item in span)
            {
                if (item.Equals(value))
                {
                    count++;
                }
            }

            return count;
        }
    }
}