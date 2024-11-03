using System;

namespace OpenMyGame.LoggerUnity.Extensions
{
    internal static class StringExtensions
    {
        public static (int, int) CountBraces(this string value)
        {
            var countOpenBraces = 0;
            var countCloseBraces = 0;

            for (var i = 0; i < value.Length; i++)
            {
                var item = value[i];

                switch (item)
                {
                    case '{':
                        countOpenBraces++;
                        break;
                    case '}':
                        countCloseBraces++;
                        break;
                }
            }

            return (countOpenBraces, countCloseBraces);
        }

        public static int IndexOfChar(this string str, char value, int indexNumber)
        {
            var currentIndex = 0;
            var currentPosition = 0;

            while (currentIndex < indexNumber)
            {
                currentPosition = str.IndexOf(value, currentPosition) + 1;

                if (currentPosition == -1)
                {
                    return -1;
                }

                currentIndex++;
            }

            return currentPosition;
        }
        
        public static int GetPositionAfterByte(this ref Span<byte> str, byte value, int indexNumber)
        {
            var currentIndex = 0;
            var cumulativePosition = 0;

            while (currentIndex < indexNumber)
            {
                var currentPosition = str.IndexOf(value) + 1;

                if (currentPosition == -1)
                {
                    return -1;
                }

                currentIndex++;
                str = str[currentPosition..];
                cumulativePosition += currentPosition;
            }
            
            return cumulativePosition;
        }
    }
}