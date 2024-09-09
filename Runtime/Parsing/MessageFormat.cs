using System.Text;
using OpenMyGame.LoggerUnity.Runtime.Messages;

namespace OpenMyGame.LoggerUnity.Runtime.Parsing
{
    public class MessageFormat
    {
        public MessageFormat(MessagePart[] messageParts)
        {
            MessageParts = messageParts;
        }

        public MessagePart[] MessageParts { get; }

        public string Render()
        {
            var sb = new StringBuilder();

            foreach (var messagePart in MessageParts)
            {
                sb.Append(messagePart.Render());
            }
            
            return sb.ToString();
        }

        public bool TryGetParameter(string parameterKey, out LogParameter logParameter)
        {
            for (var i = 0; i < MessageParts.Length; i++)
            {
                var messagePart = MessageParts[i];
                
                if (messagePart.IsParameter() && messagePart.AttachedParameter.Key == parameterKey)
                {
                    logParameter = messagePart.AttachedParameter;
                    return true;
                }
            }

            logParameter = null;
            return false;
        }
    }
}