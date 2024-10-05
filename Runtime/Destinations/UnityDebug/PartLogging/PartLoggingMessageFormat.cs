using System.Text;
using OpenMyGame.LoggerUnity.Parsing;
using OpenMyGame.LoggerUnity.Parsing.Models;

namespace OpenMyGame.LoggerUnity.Destinations.UnityDebug.PartLogging
{
    internal class PartLoggingMessageFormat
    {
        private readonly MessagePart[] _messageParts;
        
        public PartLoggingMessageFormat(string format)
        {
            var parser = new MessageFormatParser();
            _messageParts = parser.Parse(format);
        }

        public string CreatePart(PartLoggingParameters parameters)
        {
            var builder = new StringBuilder();

            foreach (var messagePart in _messageParts)
            {
                if (!messagePart.IsParameter)
                {
                    builder.Append(messagePart.GetValue());
                }
                else
                {
                    var parameterName = messagePart.GetValueAsString();
                    var parameter = parameters.GetParameter(parameterName);
                    builder.Append(parameter);
                }
            }
            
            return builder.ToString();
        }
    }
}