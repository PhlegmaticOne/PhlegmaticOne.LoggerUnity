using System;
using System.Collections.Generic;
using OpenMyGame.LoggerUnity.Infrastructure.Pools.Providers;
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
            IMessageFormatParameterSerializer parameterSerializer,
            IPoolProvider poolProvider)
        {
            FormatParameters = formatParameters;
            ParameterSerializer = parameterSerializer;
            PoolProvider = poolProvider;
        }

        /// <summary>
        /// Кастомные типы параметров в сообщениях
        /// </summary>
        public Dictionary<Type, IMessageFormatParameter> FormatParameters { get; }
        
        /// <summary>
        /// Сериализотор, используемый для парметров с префиксом @
        /// </summary>
        public IMessageFormatParameterSerializer ParameterSerializer { get; }
        
        /// <summary>
        /// Пулы для переиспользуемых объектов
        /// </summary>
        public IPoolProvider PoolProvider { get; }
    }
}