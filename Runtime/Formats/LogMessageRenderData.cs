using System;
using Openmygame.Logger.Formats.Message;
using Openmygame.Logger.Infrastructure.StringBuilders;
using Openmygame.Logger.Parsing.Models;

namespace Openmygame.Logger.Formats
{
    public readonly ref struct LogMessageRenderData
    {
        private readonly Span<object> _parameters;
        private readonly IMessageFormat _messageFormat;
        private readonly MessagePart[] _messageParts;
        
        public LogMessageRenderData(IMessageFormat messageFormat, Span<object> parameters, MessagePart[] messageParts)
        {
            _messageFormat = messageFormat;
            _parameters = parameters;
            _messageParts = messageParts;
        }

        public void Render(ref ValueStringBuilder destination)
        {
            _messageFormat.Render(ref destination, _messageParts, _parameters);
        }
    }
}