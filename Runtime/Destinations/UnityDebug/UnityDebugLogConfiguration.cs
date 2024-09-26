using OpenMyGame.LoggerUnity.Base;

namespace OpenMyGame.LoggerUnity.Destinations.UnityDebug
{
    public class UnityDebugLogConfiguration : LogConfiguration
    {
        public int MessagePartMaxSize { get; set; } = int.MaxValue;
        public bool IsUnityStacktraceEnabled { get; set; } = true;
    }
}