using OpenMyGame.LoggerUnity.Runtime.Base;

namespace OpenMyGame.LoggerUnity.Runtime.UnityDebug
{
    public class UnityDebugConfiguration : LogConfiguration
    {
        public int MessagePartMaxSize { get; set; }
        public bool IsUnityStacktraceEnabled { get; set; }
    }
}