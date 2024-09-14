using System;
using System.Runtime.InteropServices;

namespace OpenMyGame.LoggerUnity.Runtime.Infrastructure
{
    [StructLayout(LayoutKind.Sequential)]
    public struct PropertyInlineArray1
    {
        private object Object1;

        public Span<object> AsSpan()
        {
            return MemoryMarshal.CreateSpan(ref Object1, 1);
        }
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public struct PropertyInlineArray2
    {
        private object Object1;
        private object Object2;

        public Span<object> AsSpan()
        {
            return MemoryMarshal.CreateSpan(ref Object1, 2);
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct PropertyInlineArray3
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
    public struct PropertyInlineArray4
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

    [StructLayout(LayoutKind.Sequential)]
    public struct PropertyInlineArray5
    {
        private object Object1;
        private object Object2;
        private object Object3;
        private object Object4;
        private object Object5;

        public Span<object> AsSpan()
        {
            return MemoryMarshal.CreateSpan(ref Object1, 5);
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct PropertyInlineArray6
    {
        private object Object1;
        private object Object2;
        private object Object3;
        private object Object4;
        private object Object5;
        private object Object6;

        public Span<object> AsSpan()
        {
            return MemoryMarshal.CreateSpan(ref Object1, 6);
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct PropertyInlineArray7
    {
        private object Object1;
        private object Object2;
        private object Object3;
        private object Object4;
        private object Object5;
        private object Object6;
        private object Object7;

        public Span<object> AsSpan()
        {
            return MemoryMarshal.CreateSpan(ref Object1, 7);
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct PropertyInlineArray8
    {
        private object Object1;
        private object Object2;
        private object Object3;
        private object Object4;
        private object Object5;
        private object Object6;
        private object Object7;
        private object Object8;

        public Span<object> AsSpan()
        {
            return MemoryMarshal.CreateSpan(ref Object1, 8);
        }
    }
}