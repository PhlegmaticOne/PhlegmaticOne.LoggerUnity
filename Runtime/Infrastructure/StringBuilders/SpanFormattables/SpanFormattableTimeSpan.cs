using System;

namespace SpanUtilities.StringBuilders.SpanFormattables
{
    internal struct SpanFormattableTimeSpan : ISpanFormattable
    {
        private TimeSpan _value;

        public SpanFormattableTimeSpan(TimeSpan value)
        {
            _value = value;
        }

        public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format)
        {
            return _value.TryFormat(destination, out charsWritten, format);
        }
    }
}