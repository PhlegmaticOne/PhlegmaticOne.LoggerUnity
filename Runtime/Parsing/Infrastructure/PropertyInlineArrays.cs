using System;
using System.Runtime.InteropServices;

namespace OpenMyGame.LoggerUnity.Parsing.Infrastructure
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct PropertyInlineArray1
    {
        private object Object1;

        public Span<object> AsSpan()
        {
            return MemoryMarshal.CreateSpan(ref Object1, 1);
        }
    }
    
    [StructLayout(LayoutKind.Sequential)]
    internal struct PropertyInlineArray2
    {
        private object Object1;
        private object Object2;

        public Span<object> AsSpan()
        {
            return MemoryMarshal.CreateSpan(ref Object1, 2);
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct PropertyInlineArray3
    {
        private object Object1;
        private object Object2;
        private object Object3;

        public Span<object> AsSpan()
        {
            return MemoryMarshal.CreateSpan(ref Object1, 3);
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct PropertyInlineArray4
    {
        private object Object1;
        private object Object2;
        private object Object3;
        private object Object4;

        public Span<object> AsSpan()
        {
            return MemoryMarshal.CreateSpan(ref Object1, 4);
        }
    }
}