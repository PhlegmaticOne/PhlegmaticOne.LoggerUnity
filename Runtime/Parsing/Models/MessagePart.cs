using System;

namespace OpenMyGame.LoggerUnity.Parsing.Models
{
    public readonly struct MessagePart
    {
        private readonly int _startIndex;
        private readonly int _endIndex;
        private readonly string _format;

        internal static MessagePart Parameter(string formatParameter)
        {
            return new MessagePart(0, formatParameter.Length, formatParameter, true);
        }
        
        internal static MessagePart Message(string message)
        {
            return new MessagePart(0, message.Length, message, false);
        }
        
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
            format = value[(index + 1)..];
            return true;
        }

        public bool HasFormat(string format)
        {
            if (!IsParameter)
            {
                return false;
            }
            
            var value = GetValue();
            var index = value.IndexOf(':');

            if (index == -1)
            {
                return false;
            }
            
            return value[(index + 1)..].Contains(format, StringComparison.OrdinalIgnoreCase);
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

            format = value[(index + 1)..];
            return true;
        }

        public bool TryGetParameter(out ReadOnlySpan<char> parameter)
        {
            if (!IsParameter)
            {
                parameter = ReadOnlySpan<char>.Empty;
                return false;
            }
            
            var value = GetValue();
            var index = value.IndexOf(':');

            parameter = index == -1 ? value : value[..index];
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
        
        public string GetValueAsString()
        {
            return GetValue().ToString();
        }

        public override string ToString()
        {
            return GetValue().ToString();
        }
    }
}