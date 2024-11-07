using System;
using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Messages.Tagging;

namespace OpenMyGame.LoggerUnity.Messages
{
    public partial struct LogMessage
    {
        internal LogMessage(LogLevel logLevel = LogLevel.Debug)
        {
            LogLevel = logLevel;
            Id = 0;
            Exception = null;
            Format = null;
            Tag = LogTag.Empty;
        }

        public LogMessage(int id, LogLevel logLevel)
        {
            Id = id;
            LogLevel = logLevel;
            Exception = null;
            Format = null;
            Tag = LogTag.Empty;
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
            return Tag.HasValue();
        }

        /// <summary>
        /// Устанавливает тег для сообщения
        /// </summary>
        public void SetTag(string tag)
        {
            if (!string.IsNullOrEmpty(tag))
            {
                Tag = new LogTag(tag);
            }
        }

        /// <summary>
        /// Устанавливает исключение для сообщения
        /// </summary>
        public void SetException(Exception exception)
        {
            if (exception is not null)
            {
                Exception = exception;
            }
        }
        
        public override string ToString()
        {
            return Format;
        }
    }
}