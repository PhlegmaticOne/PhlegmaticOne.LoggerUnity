using System.Runtime.CompilerServices;
using System;
using System.Runtime.InteropServices;
using SpanUtilities.StringBuilders.SpanFormattables;

namespace SpanUtilities.StringBuilders
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
        public void Append(ValueStringBuilder valueStringBuilder)
        {
            Append(valueStringBuilder.AsSpan());
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
        public void AppendLine(ReadOnlySpan<char> value)
        {
            Append(value);
            AppendLine();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(Guid value, ReadOnlySpan<char> format = default, int bufferSize = 36)
        {
            Append(new SpanFormattableGuid(value), format, bufferSize);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(int value, ReadOnlySpan<char> format = default, int bufferSize = 36)
        {
            Append(new SpanFormattableInt32(value), format, bufferSize);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(float value, ReadOnlySpan<char> format = default, int bufferSize = 36)
        {
            Append(new SpanFormattableFloat(value), format, bufferSize);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(double value, ReadOnlySpan<char> format = default, int bufferSize = 36)
        {
            Append(new SpanFormattableDouble(value), format, bufferSize);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(byte value, ReadOnlySpan<char> format = default, int bufferSize = 36)
        {
            Append(new SpanFormattableByte(value), format, bufferSize);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(long value, ReadOnlySpan<char> format = default, int bufferSize = 36)
        {
            Append(new SpanFormattableInt64(value), format, bufferSize);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(short value, ReadOnlySpan<char> format = default, int bufferSize = 36)
        {
            Append(new SpanFormattableInt16(value), format, bufferSize);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(sbyte value, ReadOnlySpan<char> format = default, int bufferSize = 36)
        {
            Append(new SpanFormattableSByte(value), format, bufferSize);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(uint value, ReadOnlySpan<char> format = default, int bufferSize = 36)
        {
            Append(new SpanFormattableUInt32(value), format, bufferSize);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(ulong value, ReadOnlySpan<char> format = default, int bufferSize = 36)
        {
            Append(new SpanFormattableUInt64(value), format, bufferSize);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(ushort value, ReadOnlySpan<char> format = default, int bufferSize = 36)
        {
            Append(new SpanFormattableUInt16(value), format, bufferSize);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(decimal value, ReadOnlySpan<char> format = default, int bufferSize = 36)
        {
            Append(new SpanFormattableDecimal(value), format, bufferSize);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(DateTime value, ReadOnlySpan<char> format = default, int bufferSize = 36)
        {
            Append(new SpanFormattableDateTime(value), format, bufferSize);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append(TimeSpan value, ReadOnlySpan<char> format = default, int bufferSize = 36)
        {
            Append(new SpanFormattableTimeSpan(value), format, bufferSize);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Append<T>(T value, ReadOnlySpan<char> format = default, int bufferSize = 36)
            where T : ISpanFormattable
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