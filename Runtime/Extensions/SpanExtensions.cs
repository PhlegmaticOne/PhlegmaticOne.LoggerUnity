using System;
using System.Runtime.InteropServices;

namespace OpenMyGame.LoggerUnity.Runtime.Extensions
{
    public static class SpanExtensions
    {
        public static ReadOnlySpan<T> ToReadOnlySpan<T>(this in Span<T> span)
        {
            return MemoryMarshal.CreateReadOnlySpan(ref span[0], span.Length);
        }
    }
}