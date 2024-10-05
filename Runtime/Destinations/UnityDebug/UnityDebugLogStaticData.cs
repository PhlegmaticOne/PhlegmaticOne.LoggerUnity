namespace OpenMyGame.LoggerUnity.Destinations.UnityDebug
{
    internal static class UnityDebugLogStaticData
    {
        public const int MessagePartMaxSize = int.MaxValue;
        public const string MessagePartFormat = "[Id: {MessageId}, Part: {PartIndex}/{PartsCount}] {MessagePart}";
        public const bool IsUnityStacktraceEnabled = true;
    }
}