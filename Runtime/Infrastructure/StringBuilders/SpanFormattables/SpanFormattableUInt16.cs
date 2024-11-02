using System;

namespace SpanUtilities.StringBuilders.SpanFormattables
{
    internal struct SpanFormattableUInt16 : ISpanFormattable
    {
        private ushort _value;

        public SpanFormattableUInt16(ushort value)
        {
            _value = value;
        }

        public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format)
        {
            return _value.TryFormat(destination, out charsWritten, format);
        }
    }
}