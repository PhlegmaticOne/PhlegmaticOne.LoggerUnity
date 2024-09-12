using System.Text;
using OpenMyGame.LoggerUnity.Runtime.Base;
using OpenMyGame.LoggerUnity.Runtime.Parsing.Base;

namespace OpenMyGame.LoggerUnity.Runtime.Parsing.Models
{
    public class MessageFormat : IMessageFormat
    {
        private readonly ILogMessagePartRenderer _messagePartRenderer;
        private readonly MessagePart[] _messageParts;

        public static MessageFormat FromString(string value, ILogMessagePartRenderer messagePartRenderer)
        {
            var messageParts = new MessagePart[]
            {
                new(0, value.Length, value, false)
            };
                
            return new MessageFormat(value, messageParts, messagePartRenderer);
        }

        public MessageFormat(string format, MessagePart[] messageParts, ILogMessagePartRenderer messagePartRenderer)
        {
            Format = format;
            _messagePartRenderer = messagePartRenderer;
            _messageParts = messageParts;
        }

        public string Format { get; }

        public string Render(LogMessage logMessage)
        {
            var logBuilder = new StringBuilder();

            foreach (var messagePart in _messageParts)
            {
                var renderMessagePart = _messagePartRenderer.Render(messagePart, logMessage);
                logBuilder.Append(renderMessagePart);
            }
            
            return logBuilder.ToString();
        }
    }
}