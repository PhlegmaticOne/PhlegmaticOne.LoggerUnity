using System;
using System.Collections.Generic;
using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Configuration.Logger;
using OpenMyGame.LoggerUnity.Infrastructure.Pools.Providers;
using OpenMyGame.LoggerUnity.Messages.Factories;
using OpenMyGame.LoggerUnity.Messages.Tagging.Providers;
using OpenMyGame.LoggerUnity.Parameters.Message.Base;
using OpenMyGame.LoggerUnity.Parameters.Message.Serializing;
using OpenMyGame.LoggerUnity.Parsing;
using OpenMyGame.LoggerUnity.Parsing.Base;

namespace OpenMyGame.LoggerUnity
{
    public class LoggerBuilder
    {
        private readonly List<ILogDestination> _loggerDestinations;
        private readonly IMessageFormatParameterSerializer _parameterSerializer;
        private readonly Dictionary<Type, IMessageFormatParameter> _formatParameters;

        private bool _isExtractStacktraceToMessages;
        private string _tagFormat;
        private bool _isEnabled;

        public LoggerBuilder()
        {
            _loggerDestinations = new List<ILogDestination>();
            _tagFormat = LoggerStaticData.TagFormat;
            _isEnabled = LoggerStaticData.IsEnabled;
            _isExtractStacktraceToMessages = LoggerStaticData.IsExtractStacktrace;
            _formatParameters = LoggerStaticData.MessageFormatParameters;
            _parameterSerializer = LoggerStaticData.MessageFormatParameterSerializer;
        }

        /// <summary>
        /// Создает логгер, используя конфигурацию
        /// </summary>
        public static ILogger FromConfig(LoggerConfig loggerConfig)
        {
            var builder = new LoggerBuilder();
            loggerConfig.Build(builder);
            return builder.CreateLogger();
        }

        /// <summary>
        /// Устанавливает будет ли происходить логгирование или нет
        /// </summary>
        /// <param name="isEnabled">Активность; дефолтный параметр - <b>true</b></param>
        public LoggerBuilder SetEnabled(bool isEnabled)
        {
            _isEnabled = isEnabled;
            return this;
        }

        /// <summary>
        /// Устанавливает формат для тегов (необходимо чтобы тег имел параметр <b>{Tag}</b>)
        /// </summary>
        /// <param name="tagFormat">Формат для тегов; дефолтный формат - <b>#{Tag}#</b></param>
        public LoggerBuilder SetTagFormat(string tagFormat)
        {
            _tagFormat = tagFormat;
            return this;
        }

        /// <summary>
        /// Устанавливает будет ли формироваться стектрейс для сообщения
        /// </summary>
        /// <param name="isExtractStacktraceToMessages">Активность формирования стектрейса; дефолтный параметр - <b>false</b></param>
        public LoggerBuilder SetIsExtractStackTracesToMessage(bool isExtractStacktraceToMessages)
        {
            _isExtractStacktraceToMessages = isExtractStacktraceToMessages;
            return this;
        }

        /// <summary>
        /// Добавляет кастомный форматтер объекта в логгируемом сообщении
        /// </summary>
        public LoggerBuilder AddMessageFormatParameter(IMessageFormatParameter formatParameter)
        {
            if (formatParameter is not null)
            {
                _formatParameters[formatParameter.PropertyType] = formatParameter;
            }
            
            return this;
        }

        /// <summary>
        /// Добавляет новый логгер в коллекцию логгеров (<see cref="ILogDestination"/>)
        /// </summary>
        /// <param name="configureDestinationAction">Метод для настройки конфигурации логгера</param>
        public LoggerBuilder LogTo<TDestination, TConfiguration>(
            Action<TConfiguration> configureDestinationAction = null)
            where TConfiguration : LogConfiguration, new()
            where TDestination : LogDestination<TConfiguration>, new()
        {
            var configuration = new TConfiguration();
            configureDestinationAction?.Invoke(configuration);
            
            _loggerDestinations.Add(new TDestination
            {
                Configuration = configuration
            });
            
            return this;
        }

        /// <summary>
        /// Создает сконфигурированный логгер (<see cref="ILogger"/>)
        /// </summary>
        public ILogger CreateLogger()
        {
            ILogger logger = new Logger(
                _loggerDestinations, GetParser(), GetLogTagProvider(), GetConfigurationParameters(), GetMessageFactory());
            
            logger.IsEnabled = _isEnabled;
            
            logger.Initialize();
            
            return logger;
        }

        private ILogTagProvider GetLogTagProvider()
        {
            return new LogTagProvider(_tagFormat);
        }

        private static IMessageFormatParser GetParser()
        {
            return new MessageFormatParserCached(new MessageFormatParser());
        }

        private LoggerConfigurationParameters GetConfigurationParameters()
        {
            var poolProvider = new PoolProvider(true);
            return new LoggerConfigurationParameters(_formatParameters, _parameterSerializer, poolProvider);
        }

        private ILogMessageFactory GetMessageFactory()
        {
            return new LogMessageFactory(_isExtractStacktraceToMessages, startStacktraceDepthLevel: 5);
        }
    }
}