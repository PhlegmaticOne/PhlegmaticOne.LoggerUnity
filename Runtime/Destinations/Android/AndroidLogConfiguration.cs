using OpenMyGame.LoggerUnity.Base;

namespace OpenMyGame.LoggerUnity.Destinations.Android
{
    public class AndroidLogConfiguration : LogConfiguration
    {
        protected override bool CanAppendStacktrace => true;
    }
}