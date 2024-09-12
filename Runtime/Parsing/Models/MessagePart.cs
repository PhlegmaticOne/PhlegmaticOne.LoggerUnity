using System;

namespace OpenMyGame.LoggerUnity.Runtime.Parsing.Models
{
    public readonly struct MessagePart
    {
        private readonly int _startIndex;
        private readonly int _endIndex;
        private readonly string _format;

        public MessagePart(int startIndex, int endIndex, string format, bool isParameter)
        {
            IsParameter = isParameter;
            _startIndex = startIndex;
            _endIndex = endIndex;
            _format = format;
        }

        public bool IsParameter { get; }

        public bool SplitParameterToValueAndFormat(out ReadOnlySpan<char> parameterValue, out ReadOnlySpan<char> format)
        {
            if (!IsParameter)
            {
                parameterValue = GetValue();
                format = ReadOnlySpan<char>.Empty;
                return false;
            }

            var value = GetValue();
            var index = value.IndexOf(':');

            if (index == -1)
            {
                format = ReadOnlySpan<char>.Empty;
                parameterValue = value;
                return false;
            }

            parameterValue = value[..index];
            format = value[index..];
            return true;
        }

        public bool TryGetFormat(out ReadOnlySpan<char> format)
        {
            if (!IsParameter)
            {
                format = ReadOnlySpan<char>.Empty;
                return false;
            }

            var value = GetValue();
            var index = value.IndexOf(':');

            if (index == -1)
            {
                format = ReadOnlySpan<char>.Empty;
                return false;
            }

            format = value[index..];
            return true;
        }

        public ReadOnlySpan<char> GetValue()
        {
            if (_startIndex == _endIndex)
            {
                return ReadOnlySpan<char>.Empty;
            }
            
            return _format.AsSpan()[_startIndex.._endIndex];
        }
    }
}