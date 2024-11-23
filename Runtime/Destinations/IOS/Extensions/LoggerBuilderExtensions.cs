using System;

namespace OpenMyGame.LoggerUnity.Destinations.IOS.Extensions
{
    public static class LoggerBuilderExtensions
    {
        public static LoggerBuilder LogToIOS(
            this LoggerBuilder loggerBuilder, Action<IOSLogConfiguration> configureAction = null)
        {
            return loggerBuilder.LogTo<IOSLogDestination, IOSLogConfiguration>(x =>
            {
                configureAction?.Invoke(x);
                x.IsEnabled = GetIsLoggerEnabled();
            });
        }

        private static bool GetIsLoggerEnabled()
        {
#if UNITY_EDITOR
            return false;
#elif UNITY_IOS
            return true;
#else
            return false;
#endif
        }
    }
}