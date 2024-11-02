using System;
using System.Buffers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SpanUtilities.StringBuilders
{
    [StructLayout(LayoutKind.Sequential)]
    public ref partial struct ValueStringBuilder
    {
        private int bufferPosition;
        private Span<char> buffer;
        private char[] arrayFromPool;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueStringBuilder Create()
        {
            return new ValueStringBuilder(32);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ValueStringBuilder(int initialCapacity)
        {
            bufferPosition = 0;
            buffer = default;
            arrayFromPool = null;
            Grow(initialCapacity);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ValueStringBuilder(ReadOnlySpan<char> initialText)
        {
            bufferPosition = 0;
            buffer = default;
            arrayFromPool = null;
            Append(initialText);
        }
        
        public readonly int Length => bufferPosition;
        public readonly int Capacity => buffer.Length;

        public readonly ref char this[int index] => ref buffer[index];
        
        public static implicit operator ValueStringBuilder(string fromString) => new(fromString.AsSpan());
        public static implicit operator ValueStringBuilder(ReadOnlySpan<char> fromString) => new(fromString);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly override string ToString()
        {
            return new string(buffer[..bufferPosition]);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly ReadOnlySpan<char> AsSpan()
        {
            return buffer[..bufferPosition];
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly ReadOnlyMemory<char> AsMemory()
        {
            return new ReadOnlyMemory<char>(arrayFromPool, 0, bufferPosition);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(ReadOnlySpan<char> span)
        {
            return span.SequenceEqual(AsSpan());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Dispose()
        {
            if (arrayFromPool is not null)
            {
                ArrayPool<char>.Shared.Return(arrayFromPool);
            }

            this = default;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void Grow(int capacity = 0)
        {
            var size = buffer.Length == 0 ? 8 : buffer.Length;

            while (size < capacity)
            {
                size *= 2;
            }

            var rented = ArrayPool<char>.Shared.Rent(size);

            if (bufferPosition > 0)
            {
                ref var sourceRef = ref MemoryMarshal.GetReference(buffer);
                ref var destinationRef = ref MemoryMarshal.GetReference(rented.AsSpan());

                Unsafe.CopyBlock(
                    ref Unsafe.As<char, byte>(ref destinationRef),
                    ref Unsafe.As<char, byte>(ref sourceRef),
                    (uint)(bufferPosition * sizeof(char)));
            }

            var oldBufferFromPool = arrayFromPool;
            buffer = arrayFromPool = rented;

            if (oldBufferFromPool is not null)
            {
                ArrayPool<char>.Shared.Return(oldBufferFromPool);
            }
        }
        
        public readonly Enumerator GetEnumerator()
        {
            return new Enumerator(buffer[..bufferPosition]);
        }

        [StructLayout(LayoutKind.Auto)]
        public ref struct Enumerator
        {
            private readonly ReadOnlySpan<char> span;
            private int index;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            internal Enumerator(ReadOnlySpan<char> span)
            {
                this.span = span;
                index = -1;
            }

            public readonly char Current
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get => span[index];
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool MoveNext()
            {
                return ++index < span.Length;
            }
        }
    }
}