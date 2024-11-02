using System;

namespace SpanUtilities.StringBuilders.SpanFormattables
{
    internal struct SpanFormattableByte : ISpanFormattable
    {
        private byte _value;

        public SpanFormattableByte(byte value)
        {
            _value = value;
        }

        public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format)
        {
            return _value.TryFormat(destination, out charsWritten, format);
        }
    }
}