using System.Collections.Generic;
using OpenMyGame.LoggerUnity.Builders;
using OpenMyGame.LoggerUnity.Configuration;
using OpenMyGame.LoggerUnity.Configuration.Logger.Destinations.Platforms;
using OpenMyGame.LoggerUnity.Formats;
using OpenMyGame.LoggerUnity.Formats.Log;
using OpenMyGame.LoggerUnity.Formats.Log.Factory;
using OpenMyGame.LoggerUnity.Formats.Message;
using OpenMyGame.LoggerUnity.Messages;
using OpenMyGame.LoggerUnity.Parameters.Log.Base;
using OpenMyGame.LoggerUnity.Parameters.Log.Processors;
using OpenMyGame.LoggerUnity.Parameters.Message.Processors;

namespace OpenMyGame.LoggerUnity.Base
{
    public abstract class LogConfiguration
    {
        private readonly Dictionary<string, ILogFormatParameter> _logFormatParameters;

        private ILogFormatFactory _logFormatFactory;
        private ILogParameterProcessor _logParameterProcessor;
        private IMessageParameterProcessor _messageParameterProcessor;

        protected LogConfiguration()
        {
            RenderAs = new RenderMessageOptions(this);
            MinimumLogLevel = LoggerConfigurationData.MinimumLogLevel;
            _logFormatParameters = LoggerConfigurationData.LogFormatParameters;
            _logParameterProcessor = LoggerConfigurationData.LogParameterProcessor;
            _messageParameterProcessor = LoggerConfigurationData.MessageParameterProcessor;
        }

        public LoggerPlatform Platform { get; set; }
        public LogLevel MinimumLogLevel { get; set; }
        public RenderMessageOptions RenderAs { get; }
        
        public void AddLogFormatParameter(ILogFormatParameter formatParameter)
        {
            if (formatParameter is not null)
            {
                _logFormatParameters[formatParameter.Key] = formatParameter;
            }
        }

        protected void SetMessageParameterPostRenderer(IMessageParameterProcessor processor)
        {
            if (processor is not null)
            {
                _messageParameterProcessor = processor;
            }
        }

        protected void SetLogParameterPostRenderer(ILogParameterProcessor processor)
        {
            if (processor is not null)
            {
                _logParameterProcessor = processor;
            }
        }
        
        internal void SetFormatFactory(ILogFormatFactory logFormatFactory)
        {
            _logFormatFactory = logFormatFactory;
        }

        internal ILogFormat CreateLogFormat(LoggerConfigurationParameters configurationParameters)
        {
            return _logFormatFactory.CreateLogFormat(new LogFormatFactoryData
            {
                LogFormatParameters = _logFormatParameters,
                LogParameterProcessor = _logParameterProcessor,
                MessageParameterProcessor = _messageParameterProcessor,
                ConfigurationParameters = configurationParameters,
            });
        }

        internal IMessageFormat CreateMessageFormat(LoggerConfigurationParameters configurationParameters)
        {
            return new MessageFormat(
                configurationParameters.FormatParameters, 
                configurationParameters.ParameterSerializer,
                _messageParameterProcessor);
        }
    }
}