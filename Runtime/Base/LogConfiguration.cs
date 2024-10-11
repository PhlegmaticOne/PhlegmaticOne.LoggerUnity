using System.Collections.Generic;
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
        private ILogParameterPostRenderer _logParameterPostRenderer;
        private IMessageParameterPostRenderer _messageParameterPostRenderer;

        protected LogConfiguration()
        {
            RenderAs = new RenderMessageOptions(this);
            IsEnabled = LoggerStaticData.IsEnabled;
            MinimumLogLevel = LoggerStaticData.MinimumLogLevel;
            _logFormatParameters = LoggerStaticData.LogFormatParameters;
            _logParameterPostRenderer = LoggerStaticData.LogParameterPostRenderer;
            _messageParameterPostRenderer = LoggerStaticData.MessageParameterPostRenderer;
        }

        protected virtual bool CanAppendStacktrace => false;
        
        /// <summary>
        /// Включает или выключает применик логов на старте
        /// </summary>
        public bool IsEnabled { get; set; }
        
        /// <summary>
        /// Устанавливает минимальный уровень логгирования сообщений
        /// </summary>
        public LogLevel MinimumLogLevel { get; set; }
        
        /// <summary>
        /// Кофнигурирует результирующий вид сообщения
        /// </summary>
        public RenderMessageOptions RenderAs { get; }

        /// <summary>
        /// Добавляет новый параметр, используемый при формировании результирующего сообщения
        /// </summary>
        public void AddLogFormatParameter(ILogFormatParameter formatParameter)
        {
            if (formatParameter is not null)
            {
                _logFormatParameters[formatParameter.Key] = formatParameter;
            }
        }

        protected void SetMessageParameterPostRenderer(IMessageParameterPostRenderer postRenderer)
        {
            if (postRenderer is not null)
            {
                _messageParameterPostRenderer = postRenderer;
            }
        }

        protected void SetLogParameterPostRenderer(ILogParameterPostRenderer postRenderer)
        {
            if (postRenderer is not null)
            {
                _logParameterPostRenderer = postRenderer;
            }
        }
        
        internal void SetFormatsFactory(ILogFormatFactory logFormatFactory)
        {
            _logFormatFactory = logFormatFactory;
        }

        internal ILogFormat CreateLogFormat(LoggerConfigurationParameters configurationParameters)
        {
            return _logFormatFactory.CreateLogFormat(new LogFormatFactoryData
            {
                LogFormatParameters = _logFormatParameters,
                LogParameterPostRenderer = _logParameterPostRenderer,
                MessageParameterPostRenderer = _messageParameterPostRenderer,
                ConfigurationParameters = configurationParameters,
                CanAppendStacktrace = CanAppendStacktrace
            });
        }

        internal IMessageFormat CreateMessageFormat(LoggerConfigurationParameters configurationParameters)
        {
            return new MessageFormat(
                configurationParameters.FormatParameters, 
                configurationParameters.ParameterSerializer,
                _messageParameterPostRenderer, 
                configurationParameters.PoolProvider);
        }
    }
}