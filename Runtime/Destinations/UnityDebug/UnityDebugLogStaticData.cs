namespace Openmygame.Logger.Destinations.UnityDebug
{
    internal static class UnityDebugLogStaticData
    {
        public const int MessagePartMaxSize = 100000000;
        public const string MessagePartFormat = "[Id: {MessageId}, Part: {PartIndex}/{PartsCount}] {MessagePart}";
        public const bool IsUnityStacktraceEnabled = true;
    }
}