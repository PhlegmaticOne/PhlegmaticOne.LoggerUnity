using System.Text;
using OpenMyGame.LoggerUnity.Runtime.Messages;
using OpenMyGame.LoggerUnity.Runtime.Properties.Container;

namespace OpenMyGame.LoggerUnity.Runtime.Parsing
{
    public class MessageFormat
    {
        private readonly ILogFormatPropertiesContainer _propertiesContainer;
        private readonly MessagePart[] _messageParts;

        public MessageFormat(MessagePart[] messageParts, ILogFormatPropertiesContainer propertiesContainer)
        {
            _propertiesContainer = propertiesContainer;
            _messageParts = messageParts;
        }

        public string Render(LogMessage logMessage)
        {
            var logBuilder = new StringBuilder();

            foreach (var messagePart in _messageParts)
            {
                var renderMessagePart = _propertiesContainer.RenderMessagePart(messagePart, logMessage);
                logBuilder.Append(renderMessagePart);
            }
            
            return logBuilder.ToString();
        }
    }
}