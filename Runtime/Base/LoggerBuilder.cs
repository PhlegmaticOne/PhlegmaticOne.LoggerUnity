using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using OpenMyGame.LoggerUnity.Runtime.Parsing;
using OpenMyGame.LoggerUnity.Runtime.Properties.Base;
using OpenMyGame.LoggerUnity.Runtime.Properties.Container;
using OpenMyGame.LoggerUnity.Runtime.Properties.Log;

namespace OpenMyGame.LoggerUnity.Runtime.Base
{
    public class LoggerBuilder
    {
        private readonly List<ILogDestination> _loggerDestinations;
        private readonly List<ILogFormatProperty> _formatProperties;

        private bool _isEnabled;

        private LoggerBuilder()
        {
            _loggerDestinations = new List<ILogDestination>();
            
            _formatProperties = new List<ILogFormatProperty>
            {
                new LogFormatPropertyException(),
                new LogFormatPropertyStacktrace(),
                new LogFormatPropertyTime(),
                new LogFormatPropertyLogLevel(),
                new LogFormatPropertyUnityTime(),
                new LogFormatPropertyNewLine(),
                new LogFormatPropertyMessage()
            };
        }
        
        public static LoggerBuilder Create()
        {
            return new LoggerBuilder();
        }

        public LoggerBuilder AddFormatProperty(ILogFormatProperty formatProperty)
        {
            _formatProperties.Add(formatProperty);
            return this;
        }

        public LoggerBuilder SetEnabled(bool isEnabled)
        {
            _isEnabled = isEnabled;
            return this;
        }

        public LoggerBuilder LogTo<TDestination, TConfiguration>(
            [CanBeNull] Action<TConfiguration> configureDestinationAction = null)
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
            var propertiesContainer = new LogFormatPropertiesContainerLog(_formatProperties);
            var formatParser = new MessageFormatParser(propertiesContainer);
            return new Logger(_loggerDestinations, formatParser, _isEnabled);
        }
    }
}