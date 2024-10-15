using System.Collections.Generic;
using OpenMyGame.LoggerUnity.Infrastructure.Pools.Base;

namespace OpenMyGame.LoggerUnity.Destinations.UnityDebug.PartLogging
{
    internal class PartLoggingParameters : IPoolable
    {
        private const string MessageId = "MessageId";
        private const string MessagePart = "MessagePart";
        private const string PartIndex = "PartIndex";
        private const string PartsCount = "PartsCount";

        private readonly Dictionary<string, object> _parameters;
        
        public PartLoggingParameters()
        {
            _parameters = new Dictionary<string, object>();
            Release();
        }

        public void SetMessageId(int messageId)
        {
            _parameters[MessageId] = messageId;
        }

        public void SetPartsCount(int partsCount)
        {
            _parameters[PartsCount] = partsCount;
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

        public void Release()
        {
            _parameters[MessageId] = 0;
            _parameters[MessagePart] = string.Empty;
            _parameters[PartIndex] = 0;
            _parameters[PartsCount] = 0;
        }
    }
}