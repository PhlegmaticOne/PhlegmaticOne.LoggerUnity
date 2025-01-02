using System;
using System.Collections.Generic;
using Openmygame.Logger.Parameters.Message.Base;
using Openmygame.Logger.Parameters.Message.Serializing;

namespace Openmygame.Logger.Builders
{
    public class LoggerConfigurationParameters
    {
        public LoggerConfigurationParameters(
            Dictionary<Type, IMessageFormatParameter> formatParameters, 
            IMessageFormatParameterSerializer parameterSerializer)
        {
            FormatParameters = formatParameters;
            ParameterSerializer = parameterSerializer;
        }

        public Dictionary<Type, IMessageFormatParameter> FormatParameters { get; }
        public IMessageFormatParameterSerializer ParameterSerializer { get; }
    }
}