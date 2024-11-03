using System.Collections.Generic;
using OpenMyGame.LoggerUnity.Parameters.Log.Base;
using OpenMyGame.LoggerUnity.Parameters.Log.Processors;
using OpenMyGame.LoggerUnity.Parameters.Message.Processors;

namespace OpenMyGame.LoggerUnity.Formats.Log.Factory
{
    /// <summary>
    /// Данные для создание форматов логов, сконфигурированные при построении логгера
    /// </summary>
    public class LogFormatFactoryData
    {
        /// <summary>
        /// Обрабатывает отрендеренный параметр сообщения
        /// </summary>
        public IMessageParameterProcessor MessageParameterProcessor { get; set; }
        
        /// <summary>
        /// Обрабатывает отрендеренный параметр логгируемого сообщения
        /// </summary>
        public ILogParameterProcessor LogParameterProcessor { get; set; }
        
        /// <summary>
        /// <see cref="LoggerConfigurationParameters"/>
        /// </summary>
        public LoggerConfigurationParameters ConfigurationParameters { get; set; }
        
        /// <summary>
        /// Кастомные параметры для формирования логгируемого сообщения
        /// </summary>
        public Dictionary<string, ILogFormatParameter> LogFormatParameters { get; set; }
    }
}