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