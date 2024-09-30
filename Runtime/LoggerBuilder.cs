using System;
using System.Collections.Generic;
using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Parameters.Message;
using OpenMyGame.LoggerUnity.Parameters.Message.Base;
using OpenMyGame.LoggerUnity.Parameters.Message.Serializing;
using OpenMyGame.LoggerUnity.Parsing;
using OpenMyGame.LoggerUnity.Parsing.Base;
using OpenMyGame.LoggerUnity.Parsing.Factories;
using OpenMyGame.LoggerUnity.Tagging.Colors;
using OpenMyGame.LoggerUnity.Tagging.Colors.ViewConfig;
using OpenMyGame.LoggerUnity.Tagging.Providers;

namespace OpenMyGame.LoggerUnity
{
    public class LoggerBuilder
    {
        private readonly List<ILogDestination> _loggerDestinations;
        private readonly Dictionary<Type, IMessageFormatParameter> _formatProperties;
        private readonly IMessageFormatParameterSerializer _parameterSerializer;

        private string _tagFormat;
        private bool _isEnabled;
        private bool _isCacheFormats;
        private ITagColorsViewConfig _tagColorsViewConfig;

        public LoggerBuilder()
        {
            _loggerDestinations = new List<ILogDestination>();
            _formatProperties = new Dictionary<Type, IMessageFormatParameter>();
            _isEnabled = true;
            _isCacheFormats = true;
            _tagFormat = "#{Tag}#";
            _parameterSerializer = new MessageFormatParameterSerializer();
            _tagColorsViewConfig = new TagColorsViewConfigRandom();
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

        public LoggerBuilder SetTagColorsViewConfig(ITagColorsViewConfig tagColorsViewConfig)
        {
            if (tagColorsViewConfig is not null)
            {
                _tagColorsViewConfig = tagColorsViewConfig;
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
            var tagColorProvider = new TagColorProvider(_tagColorsViewConfig);
            return new LogTagProvider(_tagFormat, tagColorProvider);
        }

        private IMessageFormatParser GetParser()
        {
            var messageFormatFactory = new MessageFormatFactoryLogMessage(_formatProperties, _parameterSerializer);
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