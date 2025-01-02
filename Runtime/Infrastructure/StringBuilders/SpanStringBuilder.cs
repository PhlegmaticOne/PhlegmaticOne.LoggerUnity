using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Openmygame.Logger.Infrastructure.StringBuilders
{
    [StructLayout(LayoutKind.Sequential)]
    public ref struct SpanStringBuilder
    {
        private int _position;
        private Span<char> _buffer;

        public SpanStringBuilder(Span<char> buffer)
        {
            _buffer = buffer;
            _position = 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsFilled()
        {
            return _position >= _buffer.Length;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(ReadOnlySpan<char> value)
        {
            if (IsFilled())
            {
                return;
            }

            if (_position + value.Length <= _buffer.Length)
            {
                value.CopyTo(_buffer[_position..]);
                _position += value.Length;
            }
            else
            {
                var length = _buffer.Length - _position;
                value.Slice(0, length).CopyTo(_buffer[_position..]);
                _position += length;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(char value)
        {
            if (!IsFilled())
            {
                _buffer[_position++] = value;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AppendLine()
        {
            Append(Environment.NewLine);
        }
    }
}