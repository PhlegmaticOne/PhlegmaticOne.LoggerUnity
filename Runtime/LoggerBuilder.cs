using System;
using System.Collections.Generic;
using OpenMyGame.LoggerUnity.Base;
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

        private bool _isExtractStacktrace;
        private bool _isPoolingEnabled;
        private bool _isCacheFormats;
        private string _tagFormat;
        private bool _isEnabled;

        public LoggerBuilder()
        {
            _loggerDestinations = new List<ILogDestination>();
            _tagFormat = LoggerStaticData.TagFormat;
            _isEnabled = LoggerStaticData.IsEnabled;
            _isCacheFormats = LoggerStaticData.IsCacheFormats;
            _isPoolingEnabled = LoggerStaticData.IsPoolingEnabled;
            _isExtractStacktrace = LoggerStaticData.IsExtractStacktrace;
            _formatParameters = LoggerStaticData.MessageFormatParameters;
            _parameterSerializer = LoggerStaticData.MessageFormatParameterSerializer;
        }

        public LoggerBuilder AddMessageFormatParameter(IMessageFormatParameter formatParameter)
        {
            if (formatParameter is not null)
            {
                _formatParameters[formatParameter.PropertyType] = formatParameter;
            }
            
            return this;
        }

        public LoggerBuilder SetTagFormat(string tagFormat)
        {
            _tagFormat = tagFormat;
            return this;
        }

        public LoggerBuilder SetEnabled(bool isEnabled)
        {
            _isEnabled = isEnabled;
            return this;
        }

        public LoggerBuilder ExtractStackTracesToMessages()
        {
            _isExtractStacktrace = true;
            return this;
        }
        
        public LoggerBuilder SetIsCacheFormats(bool isCacheFormats)
        {
            _isCacheFormats = isCacheFormats;
            return this;
        }

        public LoggerBuilder SetIsPoolingEnabled(bool isPoolingEnabled)
        {
            _isPoolingEnabled = isPoolingEnabled;
            return this;
        }

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

        private IMessageFormatParser GetParser()
        {
            var messageFormatParser = new MessageFormatParser();
            return _isCacheFormats ? new MessageFormatParserCached(messageFormatParser) : messageFormatParser;
        }

        private LoggerConfigurationParameters GetConfigurationParameters()
        {
            var poolProvider = new PoolProvider(_isPoolingEnabled);
            return new LoggerConfigurationParameters(_formatParameters, _parameterSerializer, poolProvider);
        }

        private ILogMessageFactory GetMessageFactory()
        {
            return new LogMessageFactory(_isExtractStacktrace, startStacktraceDepthLevel: 5);
        }
    }
}