using System;
using OpenMyGame.LoggerUnity.Builders;

namespace OpenMyGame.LoggerUnity.Destinations.IOS.Extensions
{
    public static class LoggerBuilderExtensions
    {
        public static LoggerBuilder LogToIOS(
            this LoggerBuilder loggerBuilder, Action<IOSLogConfiguration> configureAction = null)
        {
            return loggerBuilder.LogTo<IOSLogDestination, IOSLogConfiguration>(x => configureAction?.Invoke(x));
        }
    }
}