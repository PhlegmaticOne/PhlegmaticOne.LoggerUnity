using System;

namespace OpenMyGame.LoggerUnity.Extensions
{
    internal static class SpanExtensions
    {
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