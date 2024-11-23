using System;
using OpenMyGame.LoggerUnity.Formats.Message;
using OpenMyGame.LoggerUnity.Infrastructure.StringBuilders;
using OpenMyGame.LoggerUnity.Parsing.Models;

namespace OpenMyGame.LoggerUnity.Formats
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