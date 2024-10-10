using System.Collections.Generic;
using OpenMyGame.LoggerUnity.Parameters.Log.Base;
using OpenMyGame.LoggerUnity.Parameters.Log.Processors;
using OpenMyGame.LoggerUnity.Parameters.Message.Processors;

namespace OpenMyGame.LoggerUnity.Formats.Log.Factory
{
    public class MessageFormatsFactoryData
    {
        public bool AppendStackTraceToRenderingMessage { get; set; }
        public IMessageParameterPostRenderer MessageParameterPostRenderer { get; set; }
        public ILogParameterPostRenderer LogParameterPostRenderer { get; set; }
        public LoggerConfigurationParameters ConfigurationParameters { get; set; }
        public Dictionary<string, ILogFormatParameter> LogFormatParameters { get; set; }
    }
}