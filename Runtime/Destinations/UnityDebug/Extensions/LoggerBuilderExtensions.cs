using System;

namespace OpenMyGame.LoggerUnity.Destinations.UnityDebug.Extensions
{
    public static class LoggerBuilderExtensions
    {
        /// <summary>
        /// Конфигурирует логгирование сообщений в консоль Unity (Debug)
        /// </summary>
        public static LoggerBuilder LogToUnityDebug(
            this LoggerBuilder loggerBuilder, Action<UnityDebugLogConfiguration> configureAction = null)
        {
            return loggerBuilder.LogTo<UnityDebugLogDestination, UnityDebugLogConfiguration>(configureAction);
        }
    }
}