using System;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.Runtime.Extensions
{
    internal static class IntegerExtensions
    {
        public static int CountDigits(this int number)
        {
            if (number == 0)
            {
                return 1;
            }

            var count = 0;
            
            while (number > 0)
            {
                number /= 10;
                count++;
            }

            return count;
        }
        
        public static char ToChar(this int number)
        {
            return (char)(number + '0');
        }
        
        public static int ToInt(this char c, int defaultValue = -1)
        {
            if (c is >= '0' and <= '9')
            {
                return c - '0';
            }

            return defaultValue;
        }

        public static string FastToString(this int value)
        {
            var length = CountDigits(value);
            Span<char> buffer = stackalloc char[length];
            
            for (var i = length - 1; i >= 0; i--)
            {
                buffer[i] = ToChar(value % 10);
                value /= 10;
            }

            return buffer.ToString();
        }

        public static void FillDigitsAsChars(
            this int number, ref int offset, int count, in Span<char> buffer)
        {
            var length = number == 0 ? 0 : (int)Mathf.Floor(Mathf.Log10(number)) + 1;
            var difference = count - length;

            while (difference > 0 && offset < buffer.Length)
            {
                buffer[offset++] = '0';
                difference--;
            }

            if (offset >= buffer.Length)
            {
                return;
            }

            for (var i = length - 1; i >= 0; i--)
            {
                buffer[i + offset] = (char)(number % 10 + '0');
                number /= 10;
            }

            offset += length;
        }
    }
}