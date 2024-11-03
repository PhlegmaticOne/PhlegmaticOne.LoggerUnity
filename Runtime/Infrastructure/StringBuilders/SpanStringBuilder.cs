using System;
using System.Text;

namespace OpenMyGame.LoggerUnity.Infrastructure.StringBuilders
{
    public unsafe ref struct SpanStringBuilder
    {
        private readonly int _length;
        private readonly byte* _array;

        public SpanStringBuilder(byte* array, int length)
        {
            _array = array;
            _length = length;
            Length = 0;
        }

        public int Length { get; private set; }

        public void Append(string value)
        {
            if (Length >= _length)
            {
                return;
            }

            fixed (char* stringPointer = value)
            {
                var canAdd = Length + value.Length <= _length ? value.Length : _length - Length;
                Length += Encoding.UTF8.GetBytes(stringPointer, canAdd, _array + Length, int.MaxValue);
            }
        }
        
        public void Append(char value)
        {
            if (Length >= _length)
            {
                return;
            }

            Span<char> temp = stackalloc char[1];
            temp[0] = value;

            fixed (char* pointer = temp)
            {
                Length += Encoding.UTF8.GetBytes(pointer, 1, _array + Length, int.MaxValue);
            }
        }
        
        public void Append(int value)
        {
            if (Length >= _length)
            {
                return;
            }

            Span<char> temp = stackalloc char[11];

            if (value.TryFormat(temp, out var charsWritten))
            {
                var canAdd = Length + charsWritten <= _length ? charsWritten : _length - Length;
                
                fixed (char* pointer = temp)
                {
                    Length += Encoding.UTF8.GetBytes(pointer, canAdd, _array + Length, int.MaxValue);
                }
            }
        }
    }
}