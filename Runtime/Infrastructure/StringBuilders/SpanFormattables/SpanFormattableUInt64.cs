using System;

namespace SpanUtilities.StringBuilders.SpanFormattables
{
    internal struct SpanFormattableUInt64 : ISpanFormattable
    {
        private ulong _value;

        public SpanFormattableUInt64(ulong value)
        {
            _value = value;
        }

        public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format)
        {
            return _value.TryFormat(destination, out charsWritten, format);
        }
    }
}