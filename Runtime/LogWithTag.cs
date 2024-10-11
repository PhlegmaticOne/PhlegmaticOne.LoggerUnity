using System;
using System.Diagnostics;
using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Messages;

namespace OpenMyGame.LoggerUnity
{
    /// <summary>
    /// Класс предназначен для логгирования сообщения с заданным тегом
    /// </summary>
    public class LogWithTag
    {
        private readonly string _tag;

        /// <summary>
        /// Создает объект для логгирования с заданным тегом
        /// </summary>
        /// <param name="tag">Тег</param>
        public LogWithTag(string tag)
        {
            _tag = tag;
        }

        /// <summary>
        /// Логгирует исключение с заданным тегом
        /// </summary>
        /// <param name="exception">Исключение</param>
        [Conditional(LoggerStaticData.ConditionalName)]
        public void Exception(Exception exception)
        {
            Log.Logger.CreateMessage(LogLevel.Fatal, stacktraceDepthLevel: 1)
                .WithTag(_tag)
                .WithException(exception)
                .Log(LoggerStaticData.ExceptionPlaceholderFormat, LoggerStaticData.ExceptionPlaceholder);
        }
        
        /// <summary>
        /// Создает сообщение с уровнем логгирования <code>Debug</code> и заданным тегом
        /// </summary>
        public LogMessage DebugMessage()
        {
            return Log.Logger
                .CreateMessage(LogLevel.Debug, stacktraceDepthLevel: 1)
                .WithTag(_tag);
        }

        /// <summary>
        /// Создает сообщение с уровнем логгирования <code>Warning</code> и заданным тегом
        /// </summary>
        public LogMessage WarningMessage()
        {
            return Log.Logger
                .CreateMessage(LogLevel.Warning, stacktraceDepthLevel: 1)
                .WithTag(_tag);
        }

        /// <summary>
        /// Создает сообщение с уровнем логгирования <code>Error</code> и заданным тегом
        /// </summary>
        public LogMessage ErrorMessage()
        {
            return Log.Logger
                .CreateMessage(LogLevel.Error, stacktraceDepthLevel: 1)
                .WithTag(_tag);
        }

        /// <summary>
        /// Создает сообщение с уровнем логгирования <code>Fatal</code> и заданным тегом
        /// </summary>
        public LogMessage FatalMessage()
        {
            return Log.Logger
                .CreateMessage(LogLevel.Fatal, stacktraceDepthLevel: 1)
                .WithTag(_tag);
        }
    }
}