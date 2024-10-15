using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Configuration.Logger.Destinations.Platforms;

namespace OpenMyGame.LoggerUnity.Destinations.Android
{
    public class AndroidLogConfiguration : LogConfiguration
    {
        public AndroidLogConfiguration()
        {
            Platform = LoggerPlatform.Android;
        }
        
        protected override bool CanAppendStacktrace => true;
    }
}