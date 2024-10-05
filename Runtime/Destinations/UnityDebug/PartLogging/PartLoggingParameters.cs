using System.Collections.Generic;
using OpenMyGame.LoggerUnity.Messages;

namespace OpenMyGame.LoggerUnity.Destinations.UnityDebug.PartLogging
{
    internal class PartLoggingParameters
    {
        private const string MessageId = "MessageId";
        private const string MessagePart = "MessagePart";
        private const string PartIndex = "PartIndex";
        private const string PartsCount = "PartsCount";

        private readonly Dictionary<string, object> _parameters;
        
        public PartLoggingParameters(LogMessage logMessage, int partsCount)
        {
            _parameters = new Dictionary<string, object>
            {
                { MessageId, logMessage.Id },
                { MessagePart, string.Empty },
                { PartIndex, 0 },
                { PartsCount, partsCount }
            };
        }

        public void IncrementPartIndex()
        {
            var partIndex = (int)_parameters[PartIndex];
            _parameters[PartIndex] = ++partIndex;
        }

        public void UpdateMessage(string message)
        {
            _parameters[MessagePart] = message;
        }

        public object GetParameter(string parameterKey)
        {
            return _parameters[parameterKey];
        }
    }
}