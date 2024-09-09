using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace OpenMyGame.LoggerUnity.Runtime.Base
{
    public class LoggerBuilder
    {
        private readonly List<ILogDestination> _loggerDestinations;

        private bool _isEnabled;

        private LoggerBuilder()
        {
            _loggerDestinations = new List<ILogDestination>();
        }
        
        public static LoggerBuilder Create()
        {
            return new LoggerBuilder();
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
            return new Logger(_loggerDestinations, _isEnabled);
        }
    }
}