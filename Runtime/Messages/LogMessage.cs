using System;
using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Messages.Tagging;

namespace OpenMyGame.LoggerUnity.Messages
{
    public partial class LogMessage
    {
        private readonly ILogger _logger;

        internal LogMessage(LogLevel logLevel = LogLevel.Debug)
        {
            LogLevel = logLevel;
        }

        public LogMessage(int id, LogLevel logLevel, LogStacktrace stacktrace, ILogger logger)
        {
            Id = id;
            LogLevel = logLevel;
            Stacktrace = stacktrace;
            _logger = logger;
        }
        
        /// <summary>
        /// Порядковый идентификатор сообщения
        /// </summary>
        public int Id { get; }
        
        /// <summary>
        /// Уровень логгирования
        /// </summary>
        public LogLevel LogLevel { get; }
        
        /// <summary>
        /// Стектрейс при вызове метода логгирования
        /// </summary>
        public LogStacktrace Stacktrace { get; }
        
        /// <summary>
        /// Исключение
        /// </summary>
        public Exception Exception { get; private set; }
        
        /// <summary>
        /// Тег сообщения
        /// </summary>
        public LogTag Tag { get; private set; }
        
        /// <summary>
        /// Формат переданный в метод <see cref="Log(string)"/>
        /// </summary>
        public string Format { get; private set; }

        /// <summary>
        /// Проверяет сообщение на наличие тега
        /// </summary>
        /// <returns><b>true</b> - тег есть, <b>false</b> - нет</returns>
        public bool HasTag()
        {
            return Tag is not null;
        }

        /// <summary>
        /// Проверяет сообщение на наличие стектрейса
        /// </summary>
        /// <returns><b>true</b> - стектрейс есть, <b>false</b> - нет</returns>
        public bool HasStacktrace()
        {
            return Stacktrace.HasValue();
        }

        /// <summary>
        /// Устанавливает тег для сообщения
        /// </summary>
        public LogMessage WithTag(string tag)
        {
            if (!string.IsNullOrEmpty(tag))
            {
                Tag = LogTag.TagOnly(tag);
            }

            return this;
        }

        /// <summary>
        /// Устанавливает исключение для сообщения
        /// </summary>
        public LogMessage WithException(Exception exception)
        {
            if (exception is not null)
            {
                Exception = exception;
            }

            return this;
        }
    }
}