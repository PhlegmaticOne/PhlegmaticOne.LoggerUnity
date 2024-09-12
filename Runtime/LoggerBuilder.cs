using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using OpenMyGame.LoggerUnity.Runtime.Base;
using OpenMyGame.LoggerUnity.Runtime.Properties.Message.Base;

namespace OpenMyGame.LoggerUnity.Runtime
{
    public class LoggerBuilder
    {
        private readonly List<ILogDestination> _loggerDestinations;
        private readonly Dictionary<Type, IMessageFormatProperty> _formatProperties;

        private bool _isEnabled;

        public LoggerBuilder()
        {
            _loggerDestinations = new List<ILogDestination>();
            _formatProperties = new Dictionary<Type, IMessageFormatProperty>();
            _isEnabled = true;
        }

        public LoggerBuilder AddLogMessageProperty(IMessageFormatProperty formatProperty)
        {
            _formatProperties[formatProperty.PropertyType] = formatProperty;
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
            var logger = new Logger(_loggerDestinations, _formatProperties, _isEnabled);
            logger.Initialize();
            return logger;
        }
    }
}