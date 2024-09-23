using System;
using System.Collections.Generic;
using OpenMyGame.LoggerUnity.Runtime.Base;
using OpenMyGame.LoggerUnity.Runtime.Parsing;
using OpenMyGame.LoggerUnity.Runtime.Parsing.Base;
using OpenMyGame.LoggerUnity.Runtime.Parsing.Factories;
using OpenMyGame.LoggerUnity.Runtime.Properties.Message;
using OpenMyGame.LoggerUnity.Runtime.Properties.Message.Base;
using OpenMyGame.LoggerUnity.Runtime.Properties.Message.Serializing;
using OpenMyGame.LoggerUnity.Runtime.Tagging.Colors;
using OpenMyGame.LoggerUnity.Runtime.Tagging.Colors.ViewConfig;
using OpenMyGame.LoggerUnity.Runtime.Tagging.Factories;

namespace OpenMyGame.LoggerUnity.Runtime
{
    public class LoggerBuilder
    {
        private readonly List<ILogDestination> _loggerDestinations;
        private readonly Dictionary<Type, IMessageFormatProperty> _formatProperties;
        private readonly IMessageFormatPropertySerializer _propertySerializer;

        private string _tagFormat;
        private bool _isEnabled;
        private bool _cacheFormats;

        public LoggerBuilder()
        {
            _loggerDestinations = new List<ILogDestination>();
            _formatProperties = new Dictionary<Type, IMessageFormatProperty>();
            _isEnabled = true;
            _cacheFormats = true;
            _tagFormat = "#{Tag}#";
            _propertySerializer = new MessageFormatPropertySerializer();
            AddMessageFormatProperties();
        }

        public LoggerBuilder AddLogMessageProperty(IMessageFormatProperty formatProperty)
        {
            if (formatProperty is not null)
            {
                AddMessageFormatProperty(formatProperty);
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
        
        public LoggerBuilder SetCacheFormats(bool isCacheFormats)
        {
            _cacheFormats = isCacheFormats;
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
            ILogger logger = new Logger(_loggerDestinations, GetParser(), GetLogWithTagFactory())
            {
                IsEnabled = _isEnabled
            };
            
            logger.Initialize();
            
            return logger;
        }

        private ILogWithTagFactory GetLogWithTagFactory()
        {
            return new LogWithTagFactory(_tagFormat);
        }

        private IMessageFormatParser GetParser()
        {
            var messageFormatFactory = new MessageFormatFactoryLogMessage(_formatProperties, _propertySerializer);
            var messageFormatParser = new MessageFormatParser(messageFormatFactory);
            return _cacheFormats ? new MessageFormatParserCached(messageFormatParser) : messageFormatParser;
        }

        private void AddMessageFormatProperties()
        {
            var tagColorProvider = new TagColorProvider(TagColorsViewConfig.Load());
            AddMessageFormatProperty(new MessageFormatPropertyString());
            AddMessageFormatProperty(new MessageFormatPropertyDateTime());
            AddMessageFormatProperty(new MessageFormatPropertyTimeSpan());
            AddMessageFormatProperty(new MessageFormatPropertyGuid());
            AddMessageFormatProperty(new MessageFormatPropertyTag(tagColorProvider));
        }
        
        private void AddMessageFormatProperty(IMessageFormatProperty formatProperty)
        {
            _formatProperties[formatProperty.PropertyType] = formatProperty;
        }
    }
}