using System;
using System.Collections.Generic;
using OpenMyGame.LoggerUnity.Parameters.Message.Base;
using OpenMyGame.LoggerUnity.Parameters.Message.Serializing;

namespace OpenMyGame.LoggerUnity
{
    public class LoggerDependencies
    {
        public LoggerDependencies(
            Dictionary<Type, IMessageFormatParameter> formatProperties, 
            IMessageFormatParameterSerializer parameterSerializer)
        {
            FormatProperties = formatProperties;
            ParameterSerializer = parameterSerializer;
        }

        public Dictionary<Type, IMessageFormatParameter> FormatProperties { get; }
        public IMessageFormatParameterSerializer ParameterSerializer { get; }
    }
}