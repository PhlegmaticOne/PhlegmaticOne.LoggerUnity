using OpenMyGame.LoggerUnity.Base;

namespace OpenMyGame.LoggerUnity.Destinations.IOS
{
    public class IOSLogConfiguration : LogConfiguration
    {
        protected override bool CanAppendStacktrace => true;
    }
}