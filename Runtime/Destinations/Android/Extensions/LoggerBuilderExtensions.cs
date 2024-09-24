using System;

namespace OpenMyGame.LoggerUnity.Destinations.Android.Extensions
{
    public static class LoggerBuilderExtensions
    {
        public static LoggerBuilder LogToAndroidLog(
            this LoggerBuilder loggerBuilder, Action<AndroidConfiguration> configureAction = null)
        {
            return loggerBuilder.LogTo<AndroidDestination, AndroidConfiguration>(x =>
            {
                configureAction?.Invoke(x);
                x.IsEnabled = GetIsLoggerEnabled();
            });
        }

        private static bool GetIsLoggerEnabled()
        {
#if UNITY_EDITOR
            return false;
#elif UNITY_ANDROID
            return true;
#else
            return false;
#endif
        }
    }
}