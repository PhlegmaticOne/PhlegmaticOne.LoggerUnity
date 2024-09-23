using OpenMyGame.LoggerUnity.Base;

namespace OpenMyGame.LoggerUnity.Destinations.UnityDebug
{
    public class UnityDebugConfiguration : LogConfiguration
    {
        public int MessagePartMaxSize { get; set; } = int.MaxValue;
        public bool IsUnityStacktraceEnabled { get; set; } = true;
    }
}