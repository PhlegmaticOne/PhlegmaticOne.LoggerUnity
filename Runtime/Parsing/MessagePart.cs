using System;
using OpenMyGame.LoggerUnity.Runtime.Messages;

namespace OpenMyGame.LoggerUnity.Runtime.Parsing
{
    public readonly struct MessagePart
    {
        private readonly int _startIndex;
        private readonly int _endIndex;
        
        public MessagePart(int startIndex, int endIndex, string format, LogParameter attachedParameter = null)
        {
            _startIndex = startIndex;
            _endIndex = endIndex;
            Format = format;
            AttachedParameter = attachedParameter;
        }
        
        public readonly string Format;
        public readonly LogParameter AttachedParameter;

        public bool IsParameter()
        {
            return AttachedParameter is not null;
        }

        public ReadOnlySpan<char> RenderFormatPart()
        {
            return Format.AsSpan()[_startIndex.._endIndex];
        }
        
        public ReadOnlySpan<char> Render()
        {
            return IsParameter() ? AttachedParameter.Render() : RenderFormatPart();
        }
    }
}