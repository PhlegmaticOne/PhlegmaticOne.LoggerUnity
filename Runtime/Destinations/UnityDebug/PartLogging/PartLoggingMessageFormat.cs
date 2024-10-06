using System.Text;
using OpenMyGame.LoggerUnity.Infrastructure.Pools.Providers;
using OpenMyGame.LoggerUnity.Parsing;
using OpenMyGame.LoggerUnity.Parsing.Models;

namespace OpenMyGame.LoggerUnity.Destinations.UnityDebug.PartLogging
{
    internal class PartLoggingMessageFormat
    {
        private readonly IPoolProvider _poolProvider;
        private readonly MessagePart[] _messageParts;
        
        public PartLoggingMessageFormat(string format, IPoolProvider poolProvider)
        {
            _poolProvider = poolProvider;
            var parser = new MessageFormatParser();
            _messageParts = parser.Parse(format);
        }

        public PartLoggingParameters CreateParameters(int messageId, int partsCount)
        {
            var parameters = _poolProvider.Get<PartLoggingParameters>();
            parameters.SetMessageId(messageId);
            parameters.SetPartsCount(partsCount);
            return parameters;
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

        public void ReturnParameters(PartLoggingParameters parameters)
        {
            _poolProvider.Return(parameters);
        }
    }
}