using System;
using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Messages.Tagging;

namespace OpenMyGame.LoggerUnity.Messages
{
    /// <summary>
    /// Класс сообщения, используемый при логгировании
    /// </summary>
    public ref partial struct LogMessage
    {
        private readonly ILogger _logger;

        internal LogMessage(LogLevel logLevel = LogLevel.Debug)
        {
            LogLevel = logLevel;
            _logger = null;
            Id = 0;
            Exception = null;
            Format = null;
            Tag = LogTag.Empty;
            StacktraceDepth = 0;
        }

        public LogMessage(int id, int stacktraceDepth, LogLevel logLevel, ILogger logger)
        {
            Id = id;
            StacktraceDepth = stacktraceDepth;
            LogLevel = logLevel;
            _logger = logger;
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
        
        public int StacktraceDepth { get; }

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
        
        /// <summary>
        /// Устанавливает тег для сообщения
        /// </summary>
        public LogMessage WithTag(string tag)
        {
            if (!string.IsNullOrEmpty(tag))
            {
                Tag = new LogTag(tag);
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

        public override string ToString()
        {
            return Format;
        }
    }
}