using System;
using System.Collections.Generic;
using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Destinations.UnityDebug.Colors.ViewConfig;
using OpenMyGame.LoggerUnity.Parameters.Message.Base;
using OpenMyGame.LoggerUnity.Parameters.Message.Serializing;
using OpenMyGame.LoggerUnity.Parsing;
using OpenMyGame.LoggerUnity.Parsing.Base;
using OpenMyGame.LoggerUnity.Tagging.Providers;

namespace OpenMyGame.LoggerUnity
{
    public class LoggerBuilder
    {
        private readonly List<ILogDestination> _loggerDestinations;
        private readonly Dictionary<Type, IMessageFormatParameter> _formatProperties;
        private readonly IMessageFormatParameterSerializer _parameterSerializer;

        private bool _isCacheFormats;
        private string _tagFormat;
        private bool _isEnabled;

        public LoggerBuilder()
        {
            _loggerDestinations = new List<ILogDestination>();
            _formatProperties = LoggerStaticData.MessageFormatParameters;
            _isEnabled = LoggerStaticData.IsEnabled;
            _isCacheFormats = LoggerStaticData.IsCacheFormats;
            _tagFormat = LoggerStaticData.TagFormat;
            _parameterSerializer = new MessageFormatParameterSerializer();
        }

        public LoggerBuilder AddMessageFormatParameter(IMessageFormatParameter formatParameter)
        {
            if (formatParameter is not null)
            {
                _formatProperties[formatParameter.PropertyType] = formatParameter;
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
            var dependencies = new LoggerDependencies(_formatProperties, _parameterSerializer);
            
            ILogger logger = new Logger(_loggerDestinations, GetParser(), GetLogWithTagProvider(), dependencies)
            {
                IsEnabled = _isEnabled
            };
            
            logger.Initialize();
            
            return logger;
        }

        private ILogTagProvider GetLogWithTagProvider()
        {
            return new LogTagProvider(_tagFormat);
        }

        private IMessageFormatParser GetParser()
        {
            var messageFormatParser = new MessageFormatParser();
            return _isCacheFormats ? new MessageFormatParserCached(messageFormatParser) : messageFormatParser;
        }
    }
}