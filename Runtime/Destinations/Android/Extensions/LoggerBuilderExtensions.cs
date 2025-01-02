using System;
using Openmygame.Logger.Builders;

namespace Openmygame.Logger.Destinations.Android.Extensions
{
    public static class LoggerBuilderExtensions
    {
        public static LoggerBuilder LogToAndroidLog(
            this LoggerBuilder loggerBuilder, Action<AndroidLogConfiguration> configureAction = null)
        {
            return loggerBuilder.LogTo<AndroidLogDestination, AndroidLogConfiguration>(x => configureAction?.Invoke(x));
        }
    }
}