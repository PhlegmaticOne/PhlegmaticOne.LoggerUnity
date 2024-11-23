using System;
using OpenMyGame.LoggerUnity.Builders;

namespace OpenMyGame.LoggerUnity.Destinations.UnityDebug.Extensions
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