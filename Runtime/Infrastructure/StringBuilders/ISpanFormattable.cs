using System;

namespace SpanUtilities.StringBuilders
{
    public interface ISpanFormattable
    {
        int BufferSize { get; }
        bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format);
    }
}