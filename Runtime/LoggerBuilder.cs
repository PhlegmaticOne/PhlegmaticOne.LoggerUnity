using System;
using System.Collections.Generic;
using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Parameters.Message;
using OpenMyGame.LoggerUnity.Parameters.Message.Base;
using OpenMyGame.LoggerUnity.Parameters.Message.Serializing;
using OpenMyGame.LoggerUnity.Parameters.Processors;
using OpenMyGame.LoggerUnity.Parameters.Processors.Colors;
using OpenMyGame.LoggerUnity.Parameters.Processors.Colors.ViewConfig;
using OpenMyGame.LoggerUnity.Parsing;
using OpenMyGame.LoggerUnity.Parsing.Base;
using OpenMyGame.LoggerUnity.Parsing.Factories;
using OpenMyGame.LoggerUnity.Tagging.Providers;

namespace OpenMyGame.LoggerUnity
{
    public class LoggerBuilder
    {
        private readonly List<ILogDestination> _loggerDestinations;
        private readonly Dictionary<Type, IMessageFormatParameter> _formatProperties;
        private readonly IMessageFormatParameterSerializer _parameterSerializer;

        private IParameterColorsViewConfig _parameterColorsViewConfig;
        private IParameterPostRenderProcessor _postRenderProcessor;
        private bool _isCacheFormats;
        private string _tagFormat;
        private bool _isEnabled;

        public LoggerBuilder()
        {
            _loggerDestinations = new List<ILogDestination>();
            _formatProperties = new Dictionary<Type, IMessageFormatParameter>();
            _isEnabled = true;
            _isCacheFormats = true;
            _tagFormat = "#{Tag}#";
            _parameterSerializer = new MessageFormatParameterSerializer();
            _postRenderProcessor = new ParameterPostRenderProcessor();
            _parameterColorsViewConfig = new ParameterColorsViewConfigRandom();
            AddMessageFormatProperties();
        }

        public LoggerBuilder AddMessageFormatParameter(IMessageFormatParameter formatParameter)
        {
            if (formatParameter is not null)
            {
                AddMessageFormatProperty(formatParameter);
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
        
        public LoggerBuilder SetIsCacheFormats(bool isCacheFormats)
        {
            _isCacheFormats = isCacheFormats;
            return this;
        }

        public LoggerBuilder ColorizeParameters(IParameterColorsViewConfig parameterColorsViewConfig)
        {
            if (parameterColorsViewConfig is not null)
            {
                _parameterColorsViewConfig = parameterColorsViewConfig;
                _postRenderProcessor = new ParameterPostRenderProcessorColorize(parameterColorsViewConfig);
            }
            
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
            ILogger logger = new Logger(_loggerDestinations, GetParser(), GetLogWithTagProvider())
            {
                IsEnabled = _isEnabled
            };
            
            logger.Initialize();
            
            return logger;
        }

        private ILogTagProvider GetLogWithTagProvider()
        {
            return new LogTagProvider(_tagFormat, _parameterColorsViewConfig);
        }

        private IMessageFormatParser GetParser()
        {
            var messageFormatFactory = new MessageFormatFactoryLogMessage(
                _formatProperties, _parameterSerializer, _postRenderProcessor);
            var messageFormatParser = new MessageFormatParser(messageFormatFactory);
            return _isCacheFormats ? new MessageFormatParserCached(messageFormatParser) : messageFormatParser;
        }

        private void AddMessageFormatProperties()
        {
            AddMessageFormatProperty(new MessageFormatParameterString());
            AddMessageFormatProperty(new MessageFormatParameterDateTime());
            AddMessageFormatProperty(new MessageFormatParameterTimeSpan());
            AddMessageFormatProperty(new MessageFormatParameterGuid());
            AddMessageFormatProperty(new MessageFormatParameterTag());
        }
        
        private void AddMessageFormatProperty(IMessageFormatParameter formatParameter)
        {
            _formatProperties[formatParameter.PropertyType] = formatParameter;
        }
    }
}