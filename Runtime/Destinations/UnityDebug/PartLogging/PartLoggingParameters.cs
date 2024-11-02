using System;

namespace OpenMyGame.LoggerUnity.Destinations.UnityDebug.PartLogging
{
    internal struct PartLoggingParameters
    {
        public const string MessageIdKey = "MessageId";
        public const string MessagePartKey = "MessagePart";
        public const string PartIndexKey = "PartIndex";
        public const string PartsCountKey = "PartsCount";

        public int MessageId { get; }
        public int PartsCount { get; }
        public int PartIndex { get; private set; }
        public ReadOnlyMemory<char> MessagePart { get; private set; }

        public PartLoggingParameters(int messageId, int partsCount)
        {
            MessageId = messageId;
            PartsCount = partsCount;
            MessagePart = ReadOnlyMemory<char>.Empty;
            PartIndex = 0;
        }

        public void IncrementPartIndex()
        {
            ++PartIndex;
        }

        public void UpdateMessage(ReadOnlyMemory<char> message)
        {
            MessagePart = message;
        }
    }
}