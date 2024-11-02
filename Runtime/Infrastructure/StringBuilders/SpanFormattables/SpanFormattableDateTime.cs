using System;

namespace SpanUtilities.StringBuilders.SpanFormattables
{
    internal struct SpanFormattableDateTime : ISpanFormattable
    {
        private DateTime _value;

        public SpanFormattableDateTime(DateTime value)
        {
            _value = value;
        }

        public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format)
        {
            return _value.TryFormat(destination, out charsWritten, format);
        }
    }
}