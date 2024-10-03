using System;

namespace OpenMyGame.LoggerUnity.Extensions
{
    internal static class SpanExtensions
    {
        public static void FillString(this in Span<char> span, string value, ref int offset)
        {
            var endIndex = offset + value.Length;
            
            for (int i = offset, j = 0; i < endIndex; i++, j++)
            {
                span[i] = value[j];
            }

            offset = endIndex;
        }
        
        public static void FillChar(this in Span<char> span, char value, ref int offset)
        {
            span[offset] = value;
            offset += 1;
        }
        
        public static void FillSpan(this in Span<char> span, in ReadOnlySpan<char> value, ref int offset)
        {
            var endIndex = offset + value.Length;
            
            for (int i = offset, j = 0; i < endIndex; i++, j++)
            {
                span[i] = value[j];
            }

            offset = endIndex;
        }

        public static bool IndexWithinRange(this in Span<object> span, int index)
        {
            return index >= 0 && index < span.Length;
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
    }
}