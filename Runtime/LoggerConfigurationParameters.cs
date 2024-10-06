using System;
using System.Collections.Generic;
using OpenMyGame.LoggerUnity.Infrastructure.Pools.Providers;
using OpenMyGame.LoggerUnity.Parameters.Message.Base;
using OpenMyGame.LoggerUnity.Parameters.Message.Serializing;

namespace OpenMyGame.LoggerUnity
{
    public class LoggerConfigurationParameters
    {
        public LoggerConfigurationParameters(
            Dictionary<Type, IMessageFormatParameter> formatProperties, 
            IMessageFormatParameterSerializer parameterSerializer,
            IPoolProvider poolProvider)
        {
            FormatProperties = formatProperties;
            ParameterSerializer = parameterSerializer;
            PoolProvider = poolProvider;
        }

        public Dictionary<Type, IMessageFormatParameter> FormatProperties { get; }
        public IMessageFormatParameterSerializer ParameterSerializer { get; }
        public IPoolProvider PoolProvider { get; }
    }
}