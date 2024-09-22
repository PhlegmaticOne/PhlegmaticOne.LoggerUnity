using OpenMyGame.LoggerUnity.Runtime.Base;

namespace OpenMyGame.LoggerUnity.Runtime.Destinations.UnityDebug
{
    public class UnityDebugConfiguration : LogConfiguration
    {
        public int MessagePartMaxSize { get; set; } = int.MaxValue;
        public bool IsUnityStacktraceEnabled { get; set; } = true;
    }
}