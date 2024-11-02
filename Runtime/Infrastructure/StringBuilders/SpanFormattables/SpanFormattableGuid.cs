using System;

namespace SpanUtilities.StringBuilders.SpanFormattables
{
    internal struct SpanFormattableGuid : ISpanFormattable
    {
        private Guid _guid;

        public SpanFormattableGuid(Guid guid)
        {
            _guid = guid;
        }
        
        public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format)
        {
            return _guid.TryFormat(destination, out charsWritten, format);
        }
    }
}