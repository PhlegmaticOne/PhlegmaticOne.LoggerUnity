using System.Collections.Generic;
using System.Linq;
using OpenMyGame.LoggerUnity.Parameters.Log.Base;
using OpenMyGame.LoggerUnity.Parameters.Log.Formats;
using OpenMyGame.LoggerUnity.Parameters.Log.Processors;
using OpenMyGame.LoggerUnity.Parameters.Message.Formats;
using OpenMyGame.LoggerUnity.Parameters.Message.Processors;
using OpenMyGame.LoggerUnity.Parsing;

namespace OpenMyGame.LoggerUnity.Base
{
    public abstract class LogConfiguration
    {
        private readonly Dictionary<string, ILogFormatParameter> _logFormatParameters;
        
        private ILogParameterPostRenderProcessor _logParameterPostRenderProcessor;
        private IMessageParameterPostRenderProcessor _messageParameterPostRenderProcessor;

        protected LogConfiguration()
        {
            LogFormat = LoggerStaticData.LogFormat;
            IsEnabled = LoggerStaticData.IsEnabled;
            MinimumLogLevel = LoggerStaticData.MinimumLogLevel;
            _logFormatParameters = LoggerStaticData.LogFormatParameters;
            _logParameterPostRenderProcessor = LoggerStaticData.LogParameterPostRenderProcessor;
            _messageParameterPostRenderProcessor = LoggerStaticData.MessageParameterPostRenderProcessor;
        }

        public bool IsEnabled { get; set; }
        public string LogFormat { set; get; }
        public LogLevel MinimumLogLevel { get; set; }

        public void AddLogFormatParameter(ILogFormatParameter formatParameter)
        {
            if (formatParameter is not null)
            {
                _logFormatParameters[formatParameter.Key] = formatParameter;
            }
        }

        public void SetMessageParameterPostRenderProcessor(IMessageParameterPostRenderProcessor postRenderProcessor)
        {
            if (postRenderProcessor is not null)
            {
                _messageParameterPostRenderProcessor = postRenderProcessor;
            }
        }
        
        public void SetLogParameterPostRenderProcessor(ILogParameterPostRenderProcessor postRenderProcessor)
        {
            if (postRenderProcessor is not null)
            {
                _logParameterPostRenderProcessor = postRenderProcessor;
            }
        }

        public ILogFormat CreateLogFormat()
        {
            var parser = new MessageFormatParser();

            return new LogFormat(
                parser.Parse(LogFormat), _logFormatParameters, _logParameterPostRenderProcessor);
        }

        public IMessageFormat CreateMessageFormat(LoggerDependencies dependencies)
        {
            return new MessageFormat(
                dependencies.FormatProperties, dependencies.ParameterSerializer, _messageParameterPostRenderProcessor);
        }
    }
}