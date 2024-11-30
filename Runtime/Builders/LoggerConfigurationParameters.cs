using System;
using System.Collections.Generic;
using OpenMyGame.LoggerUnity.Parameters.Message.Base;
using OpenMyGame.LoggerUnity.Parameters.Message.Serializing;

namespace OpenMyGame.LoggerUnity.Builders
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