using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Configuration.Logger.Destinations.Platforms;

namespace OpenMyGame.LoggerUnity.Destinations.IOS
{
    public class IOSLogConfiguration : LogConfiguration
    {
        public IOSLogConfiguration()
        {
            Platform = LoggerPlatform.Ios;
        }
    }
}