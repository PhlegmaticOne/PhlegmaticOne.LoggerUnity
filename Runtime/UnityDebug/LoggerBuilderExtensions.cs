using System;

namespace OpenMyGame.LoggerUnity.Runtime.UnityDebug
{
    public static class LoggerBuilderExtensions
    {
        public static LoggerBuilder LogToUnityDebug(
            this LoggerBuilder loggerBuilder, Action<UnityDebugConfiguration> configureAction = null)
        {
            return loggerBuilder.LogTo<UnityDebugDestination, UnityDebugConfiguration>(configureAction);
        }
    }
}