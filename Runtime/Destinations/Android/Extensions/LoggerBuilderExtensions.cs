using System;
using OpenMyGame.LoggerUnity.Builders;

namespace OpenMyGame.LoggerUnity.Destinations.Android.Extensions
{
    public static class LoggerBuilderExtensions
    {
        public static LoggerBuilder LogToAndroidLog(
            this LoggerBuilder loggerBuilder, Action<AndroidLogConfiguration> configureAction = null)
        {
            return loggerBuilder.LogTo<AndroidLogDestination, AndroidLogConfiguration>(x =>
            {
                configureAction?.Invoke(x);
            });
        }
    }
}