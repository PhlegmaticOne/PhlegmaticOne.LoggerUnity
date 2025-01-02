using System;
using Openmygame.Logger.Builders;

namespace Openmygame.Logger.Destinations.UnityDebug.Extensions
{
    public static class LoggerBuilderExtensions
    {
        public static LoggerBuilder LogToUnityDebug(
            this LoggerBuilder loggerBuilder, Action<UnityDebugLogConfiguration> configureAction = null)
        {
            return loggerBuilder.LogTo<UnityDebugLogDestination, UnityDebugLogConfiguration>(configureAction);
        }
    }
}