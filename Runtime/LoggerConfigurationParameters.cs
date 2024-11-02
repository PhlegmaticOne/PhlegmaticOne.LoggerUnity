using System;
using System.Collections.Generic;
using OpenMyGame.LoggerUnity.Parameters.Message.Base;
using OpenMyGame.LoggerUnity.Parameters.Message.Serializing;

namespace OpenMyGame.LoggerUnity
{
    /// <summary>
    /// Сконфигурированные данные в <see cref="LoggerBuilder"/>, используемые при настройке приемников логов
    /// </summary>
    public class LoggerConfigurationParameters
    {
        public LoggerConfigurationParameters(
            Dictionary<Type, IMessageFormatParameter> formatParameters, 
            IMessageFormatParameterSerializer parameterSerializer)
        {
            FormatParameters = formatParameters;
            ParameterSerializer = parameterSerializer;
        }

        /// <summary>
        /// Кастомные типы параметров в сообщениях
        /// </summary>
        public Dictionary<Type, IMessageFormatParameter> FormatParameters { get; }
        
        /// <summary>
        /// Сериализатор, используемый для парметров с префиксом <b>@</b>
        /// </summary>
        public IMessageFormatParameterSerializer ParameterSerializer { get; }
    }
}