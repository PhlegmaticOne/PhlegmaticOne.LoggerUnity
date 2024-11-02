﻿using System;

namespace SpanUtilities.StringBuilders.SpanFormattables
{
    internal struct SpanFormattableInt64 : ISpanFormattable
    {
        private long _value;

        public SpanFormattableInt64(long value)
        {
            _value = value;
        }

        public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format)
        {
            return _value.TryFormat(destination, out charsWritten, format);
        }
    }
}