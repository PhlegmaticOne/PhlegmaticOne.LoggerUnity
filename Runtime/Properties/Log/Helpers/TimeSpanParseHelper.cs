using System;
using OpenMyGame.LoggerUnity.Runtime.Extensions;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.Runtime.Properties.Log.Helpers
{
    internal static class TimeSpanParseHelper
    {
        public static ReadOnlySpan<char> ParseCustomFormat(TimeSpan timeSpan, ReadOnlySpan<char> format)
        {
            var currentIndex = 0;
            var leadingTimeUnit = format[0];
            var hasHourUnit = format.Contains("hh", StringComparison.OrdinalIgnoreCase);
            var hasMinuteUnit = format.Contains("mm", StringComparison.OrdinalIgnoreCase);
            var hasSecondUnit = format.Contains("ss", StringComparison.OrdinalIgnoreCase);
            var hasMillisecondUnit = format.Contains("ms", StringComparison.OrdinalIgnoreCase);
            var millisecondLength = format[^1].ToInt(defaultValue: 3);

            var leadingTiming = GetLeadingTiming(leadingTimeUnit, timeSpan);
            var totalCount = Mathf.Max(2, leadingTiming.CountDigits()) + 1;

            if (hasMinuteUnit && !hasHourUnit)
            {
                totalCount += 3;
            }

            if (hasSecondUnit)
            {
                totalCount += 3;
            }

            if (hasMillisecondUnit)
            {
                totalCount += millisecondLength;
            }
            
            Span<char> buffer = stackalloc char[totalCount];
            
            leadingTiming.FillDigitsAsChars(ref currentIndex, 2, buffer);
            FillSeparator(format, buffer, ref currentIndex);

            if (hasMinuteUnit)
            {
                timeSpan.Minutes.FillDigitsAsChars(ref currentIndex, 2, buffer);
                FillSeparator(format, buffer, ref currentIndex);
            }

            if (hasSecondUnit)
            {
                timeSpan.Seconds.FillDigitsAsChars(ref currentIndex, 2, buffer);
                FillSeparator(format, buffer, ref currentIndex);
            }

            if (hasMillisecondUnit)
            {
                timeSpan.Milliseconds.FillDigitsAsChars(ref currentIndex, 3, buffer);
            }

            return buffer.ToString();
        }

        private static void FillSeparator(in ReadOnlySpan<char> format, in Span<char> buffer, ref int currentIndex)
        {
            buffer[currentIndex] = format[currentIndex];
            currentIndex++;
        }

        private static int GetLeadingTiming(char leadingTiming, in TimeSpan time)
        {
            return leadingTiming switch
            {
                'h' => (int)time.TotalHours,
                'm' => (int)time.TotalMinutes,
                's' => (int)time.TotalSeconds,
                _ => throw new ArgumentException()
            };
        }
    }
}