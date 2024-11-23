using System.Runtime.CompilerServices;
using System;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenMyGame.LoggerUnity.Infrastructure.StringBuilders
{
    public partial struct ValueStringBuilder
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(bool value)
        {
            var newSize = bufferPosition + 5;
            
            if (newSize > buffer.Length)
            {
                Grow(newSize);
            }

            if (!value.TryFormat(buffer[bufferPosition..], out var charsWritten))
            {
                throw new InvalidOperationException($"Could not add {value} to the builder.");
            }

            bufferPosition += charsWritten;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(ReadOnlySpan<char> value)
        {
            if (value.IsEmpty)
            {
                return;
            }
            
            var newSize = value.Length + bufferPosition;
            
            if (newSize > buffer.Length)
            {
                Grow(newSize);
            }

            ref var strRef = ref MemoryMarshal.GetReference(value);
            ref var bufferRef = ref MemoryMarshal.GetReference(buffer[bufferPosition..]);
            
            Unsafe.CopyBlock(
                ref Unsafe.As<char, byte>(ref bufferRef),
                ref Unsafe.As<char, byte>(ref strRef),
                (uint)(value.Length * sizeof(char)));

            bufferPosition += value.Length;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AppendEncodedBytes(ReadOnlySpan<byte> value)
        {
            if (value.IsEmpty)
            {
                return;
            }
            
            var newSize = value.Length + bufferPosition;
            
            if (newSize > buffer.Length)
            {
                Grow(newSize);
            }

            Encoding.UTF8.GetChars(value, buffer[bufferPosition..]);
            bufferPosition += value.Length;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(ReadOnlyMemory<char> memory)
        {
            Append(memory.Span);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(char value)
        {
            var newSize = bufferPosition + 1;
            
            if (newSize > buffer.Length)
            {
                Grow(newSize);
            }

            buffer[bufferPosition] = value;
            bufferPosition++;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AppendLine()
        {
            Append(Environment.NewLine);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(Guid value, ReadOnlySpan<char> format = default, int bufferSize = 36)
        {
            var newSize = bufferSize + bufferPosition;
            
            if (newSize >= Capacity)
            {
                Grow(newSize);
            }

            if (!value.TryFormat(buffer[bufferPosition..], out var written, format))
            {
                throw new InvalidOperationException($"Could not insert {value} into given buffer. Is the buffer (size: {bufferSize}) large enough?");
            }

            bufferPosition += written;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(int value, ReadOnlySpan<char> format = default, int bufferSize = 11)
        {
            var newSize = bufferSize + bufferPosition;
            
            if (newSize >= Capacity)
            {
                Grow(newSize);
            }

            if (!value.TryFormat(buffer[bufferPosition..], out var written, format))
            {
                throw new InvalidOperationException($"Could not insert {value} into given buffer. Is the buffer (size: {bufferSize}) large enough?");
            }

            bufferPosition += written;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(float value, ReadOnlySpan<char> format = default, int bufferSize = 24)
        {
            var newSize = bufferSize + bufferPosition;
            
            if (newSize >= Capacity)
            {
                Grow(newSize);
            }

            if (!value.TryFormat(buffer[bufferPosition..], out var written, format))
            {
                throw new InvalidOperationException($"Could not insert {value} into given buffer. Is the buffer (size: {bufferSize}) large enough?");
            }

            bufferPosition += written;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(double value, ReadOnlySpan<char> format = default, int bufferSize = 36)
        {
            var newSize = bufferSize + bufferPosition;
            
            if (newSize >= Capacity)
            {
                Grow(newSize);
            }

            if (!value.TryFormat(buffer[bufferPosition..], out var written, format))
            {
                throw new InvalidOperationException($"Could not insert {value} into given buffer. Is the buffer (size: {bufferSize}) large enough?");
            }

            bufferPosition += written;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(byte value, ReadOnlySpan<char> format = default, int bufferSize = 3)
        {
            var newSize = bufferSize + bufferPosition;
            
            if (newSize >= Capacity)
            {
                Grow(newSize);
            }

            if (!value.TryFormat(buffer[bufferPosition..], out var written, format))
            {
                throw new InvalidOperationException($"Could not insert {value} into given buffer. Is the buffer (size: {bufferSize}) large enough?");
            }

            bufferPosition += written;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(long value, ReadOnlySpan<char> format = default, int bufferSize = 21)
        {
            var newSize = bufferSize + bufferPosition;
            
            if (newSize >= Capacity)
            {
                Grow(newSize);
            }

            if (!value.TryFormat(buffer[bufferPosition..], out var written, format))
            {
                throw new InvalidOperationException($"Could not insert {value} into given buffer. Is the buffer (size: {bufferSize}) large enough?");
            }

            bufferPosition += written;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(short value, ReadOnlySpan<char> format = default, int bufferSize = 6)
        {
            var newSize = bufferSize + bufferPosition;
            
            if (newSize >= Capacity)
            {
                Grow(newSize);
            }

            if (!value.TryFormat(buffer[bufferPosition..], out var written, format))
            {
                throw new InvalidOperationException($"Could not insert {value} into given buffer. Is the buffer (size: {bufferSize}) large enough?");
            }

            bufferPosition += written;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(sbyte value, ReadOnlySpan<char> format = default, int bufferSize = 4)
        {
            var newSize = bufferSize + bufferPosition;
            
            if (newSize >= Capacity)
            {
                Grow(newSize);
            }

            if (!value.TryFormat(buffer[bufferPosition..], out var written, format))
            {
                throw new InvalidOperationException($"Could not insert {value} into given buffer. Is the buffer (size: {bufferSize}) large enough?");
            }

            bufferPosition += written;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(uint value, ReadOnlySpan<char> format = default, int bufferSize = 10)
        {
            var newSize = bufferSize + bufferPosition;
            
            if (newSize >= Capacity)
            {
                Grow(newSize);
            }

            if (!value.TryFormat(buffer[bufferPosition..], out var written, format))
            {
                throw new InvalidOperationException($"Could not insert {value} into given buffer. Is the buffer (size: {bufferSize}) large enough?");
            }

            bufferPosition += written;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(ulong value, ReadOnlySpan<char> format = default, int bufferSize = 20)
        {
            var newSize = bufferSize + bufferPosition;
            
            if (newSize >= Capacity)
            {
                Grow(newSize);
            }

            if (!value.TryFormat(buffer[bufferPosition..], out var written, format))
            {
                throw new InvalidOperationException($"Could not insert {value} into given buffer. Is the buffer (size: {bufferSize}) large enough?");
            }

            bufferPosition += written;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(ushort value, ReadOnlySpan<char> format = default, int bufferSize = 5)
        {
            var newSize = bufferSize + bufferPosition;
            
            if (newSize >= Capacity)
            {
                Grow(newSize);
            }

            if (!value.TryFormat(buffer[bufferPosition..], out var written, format))
            {
                throw new InvalidOperationException($"Could not insert {value} into given buffer. Is the buffer (size: {bufferSize}) large enough?");
            }

            bufferPosition += written;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(decimal value, ReadOnlySpan<char> format = default, int bufferSize = 40)
        {
            var newSize = bufferSize + bufferPosition;
            
            if (newSize >= Capacity)
            {
                Grow(newSize);
            }

            if (!value.TryFormat(buffer[bufferPosition..], out var written, format))
            {
                throw new InvalidOperationException($"Could not insert {value} into given buffer. Is the buffer (size: {bufferSize}) large enough?");
            }

            bufferPosition += written;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(DateTime value, ReadOnlySpan<char> format = default, int bufferSize = 40)
        {
            var newSize = bufferSize + bufferPosition;
            
            if (newSize >= Capacity)
            {
                Grow(newSize);
            }

            if (!value.TryFormat(buffer[bufferPosition..], out var written, format))
            {
                throw new InvalidOperationException($"Could not insert {value} into given buffer. Is the buffer (size: {bufferSize}) large enough?");
            }

            bufferPosition += written;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(TimeSpan value, ReadOnlySpan<char> format = default, int bufferSize = 13)
        {
            var newSize = bufferSize + bufferPosition;
            
            if (newSize >= Capacity)
            {
                Grow(newSize);
            }

            if (!value.TryFormat(buffer[bufferPosition..], out var written, format))
            {
                throw new InvalidOperationException($"Could not insert {value} into given buffer. Is the buffer (size: {bufferSize}) large enough?");
            }

            bufferPosition += written;
        }
    }
}