using System.Collections.Generic;
using Openmygame.Logger.Builders;
using Openmygame.Logger.Parameters.Log.Base;
using Openmygame.Logger.Parameters.Log.Processors;
using Openmygame.Logger.Parameters.Message.Processors;

namespace Openmygame.Logger.Formats.Log.Factory
{
    public class LogFormatFactoryData
    {
        public IMessageParameterProcessor MessageParameterProcessor { get; set; }
        public ILogParameterProcessor LogParameterProcessor { get; set; }
        public LoggerConfigurationParameters ConfigurationParameters { get; set; }
        public Dictionary<string, ILogFormatParameter> LogFormatParameters { get; set; }
    }
}