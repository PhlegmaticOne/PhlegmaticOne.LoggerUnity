using System;

namespace SpanUtilities.StringBuilders
{
    public interface ISpanFormattable
    {
        bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format);
    }
}