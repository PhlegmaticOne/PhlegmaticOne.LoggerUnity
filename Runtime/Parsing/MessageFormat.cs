using System.Text;
using OpenMyGame.LoggerUnity.Runtime.Messages;
using OpenMyGame.LoggerUnity.Runtime.Properties.Container;

namespace OpenMyGame.LoggerUnity.Runtime.Parsing
{
    public class MessageFormat
    {
        private readonly ILogMessagePartRenderer _messagePartRenderer;
        private readonly MessagePart[] _messageParts;

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