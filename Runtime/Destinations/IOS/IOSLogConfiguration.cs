using Openmygame.Logger.Base;
using Openmygame.Logger.Configuration.Logger.Destinations.Platforms;

namespace Openmygame.Logger.Destinations.IOS
{
    public class IOSLogConfiguration : LogConfiguration
    {
        public IOSLogConfiguration()
        {
            Platform = LoggerPlatform.Ios;
        }
    }
}