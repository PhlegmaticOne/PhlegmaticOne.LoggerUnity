using System;
using System.Collections.Generic;
using OpenMyGame.LoggerUnity.Runtime.Base;
using OpenMyGame.LoggerUnity.Runtime.Parsing;
using OpenMyGame.LoggerUnity.Runtime.Parsing.Factories;
using OpenMyGame.LoggerUnity.Runtime.Properties.Message;
using OpenMyGame.LoggerUnity.Runtime.Properties.Message.Base;
using OpenMyGame.LoggerUnity.Runtime.Properties.Message.Serializing;
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

        public LoggerBuilder()
        {
            _loggerDestinations = new List<ILogDestination>();
            _formatProperties = new Dictionary<Type, IMessageFormatProperty>();
            _isEnabled = true;
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
            var messageFormatFactory = new MessageFormatFactoryLogMessage(_formatProperties, _propertySerializer);
            var messageFormatParser = new MessageFormatParser(messageFormatFactory);
            var logWithTagFactory = new LogWithTagFactory(_tagFormat);
            
            ILogger logger = new Logger(_loggerDestinations, messageFormatParser, logWithTagFactory)
            {
                IsEnabled = _isEnabled
            };
            
            logger.Initialize();
            return logger;
        }

        private void AddMessageFormatProperties()
        {
            AddMessageFormatProperty(new MessageFormatPropertyString());
            AddMessageFormatProperty(new MessageFormatPropertyDateTime());
            AddMessageFormatProperty(new MessageFormatPropertyTimeSpan());
            AddMessageFormatProperty(new MessageFormatPropertyGuid());
        }
        
        private void AddMessageFormatProperty(IMessageFormatProperty formatProperty)
        {
            _formatProperties[formatProperty.PropertyType] = formatProperty;
        }
    }
}