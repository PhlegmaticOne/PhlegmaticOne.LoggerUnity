using OpenMyGame.LoggerUnity.Base;

namespace OpenMyGame.LoggerUnity.Extensions
{
    public static class LoggerExtensions
    {
        public static void SetDebugEnabled(this ILogger logger, bool isEnabled)
        {
            logger.SetDestinationEnabled(LogDestinationsSupported.Debug, isEnabled);
        }
        
        public static void SetAndroidLogEnabled(this ILogger logger, bool isEnabled)
        {
            logger.SetDestinationEnabled(LogDestinationsSupported.Android, isEnabled);
        }
        
        public static void SetIOSEnabled(this ILogger logger, bool isEnabled)
        {
            logger.SetDestinationEnabled(LogDestinationsSupported.IOS, isEnabled);
        }
    }
}