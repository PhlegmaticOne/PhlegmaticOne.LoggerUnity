using System;

namespace OpenMyGame.LoggerUnity.Destinations.Android.Extensions
{
    public static class LoggerBuilderExtensions
    {
        /// <summary>
        /// Конфигурирует логгирование сообщений в Android
        /// </summary>
        public static LoggerBuilder LogToAndroidLog(
            this LoggerBuilder loggerBuilder, Action<AndroidLogConfiguration> configureAction = null)
        {
            return loggerBuilder.LogTo<AndroidLogDestination, AndroidLogConfiguration>(x =>
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