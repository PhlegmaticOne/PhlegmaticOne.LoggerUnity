using System.Collections.Generic;
using OpenMyGame.LoggerUnity.Builders;
using OpenMyGame.LoggerUnity.Parameters.Log.Base;
using OpenMyGame.LoggerUnity.Parameters.Log.Processors;
using OpenMyGame.LoggerUnity.Parameters.Message.Processors;

namespace OpenMyGame.LoggerUnity.Formats.Log.Factory
{
    public class LogFormatFactoryData
    {
        public IMessageParameterProcessor MessageParameterProcessor { get; set; }
        public ILogParameterProcessor LogParameterProcessor { get; set; }
        public LoggerConfigurationParameters ConfigurationParameters { get; set; }
        public Dictionary<string, ILogFormatParameter> LogFormatParameters { get; set; }
    }
}