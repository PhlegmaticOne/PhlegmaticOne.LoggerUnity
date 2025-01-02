using Openmygame.Logger.Base;
using Openmygame.Logger.Configuration.Logger.Destinations.Platforms;

namespace Openmygame.Logger.Destinations.Android
{
    public class AndroidLogConfiguration : LogConfiguration
    {
        public AndroidLogConfiguration()
        {
            Platform = LoggerPlatform.Android;
        }
    }
}