using System;
using System.Runtime.InteropServices;

namespace Openmygame.Logger.Infrastructure.InlineArrays
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct PropertyInlineArray
    {
        private object Object1;

        public Span<object> AsSpan()
        {
            return MemoryMarshal.CreateSpan(ref Object1, 1);
        }
    }
}