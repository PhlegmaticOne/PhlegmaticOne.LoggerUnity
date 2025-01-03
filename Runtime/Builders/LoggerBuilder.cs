using System;
using System.Collections.Generic;
using Openmygame.Logger.Base;
using Openmygame.Logger.Configuration;
using Openmygame.Logger.Configuration.Logger;
using Openmygame.Logger.Configuration.Logger.Destinations.Platforms;
using Openmygame.Logger.Parameters.Message.Base;
using Openmygame.Logger.Parameters.Message.Serializing;
using Openmygame.Logger.Parsing;
using Openmygame.Logger.Parsing.Base;

namespace Openmygame.Logger.Builders
{
    public sealed class LoggerBuilder
    {
        private readonly List<ILogDestination> _logDestinations;
        private readonly IMessageFormatParameterSerializer _parameterSerializer;
        private readonly Dictionary<Type, IMessageFormatParameter> _formatParameters;

        private bool _isExtractStacktrace;
        private bool _isEnabled;

        public LoggerBuilder()
        {
            _logDestinations = new List<ILogDestination>();
            _isEnabled = LoggerConfigurationData.IsEnabled;
            _isExtractStacktrace = LoggerConfigurationData.IsExtractStacktrace;
            _formatParameters = LoggerConfigurationData.MessageFormatParameters;
            _parameterSerializer = LoggerConfigurationData.MessageFormatParameterSerializer;
        }

        public static ILogger FromConfig(LoggerConfig loggerConfig)
        {
            var builder = new LoggerBuilder();
            loggerConfig.Build(builder);
            return builder.CreateLogger();
        }

        public LoggerBuilder SetEnabled(bool isEnabled)
        {
            _isEnabled = isEnabled;
            return this;
        }

        public LoggerBuilder SetIsExtractStacktrace(bool isExtractStacktrace)
        {
            _isExtractStacktrace = isExtractStacktrace;
            return this;
        }

        public LoggerBuilder AddMessageFormatParameter(IMessageFormatParameter formatParameter)
        {
            if (formatParameter is not null)
            {
                _formatParameters[formatParameter.PropertyType] = formatParameter;
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

            if (LoggerPlatformProvider.HasPlatform(configuration.Platform))
            {
                _logDestinations.Add(new TDestination
                {
                    Configuration = configuration
                });
            }
            
            return this;
        }

        public ILogger CreateLogger()
        {
            return new Logger(GetInitializedDestinations(), GetParser(), _isExtractStacktrace, _isEnabled);
        }

        private ILogDestination[] GetInitializedDestinations()
        {
            var logDestinations = _logDestinations.ToArray();
            var configurationParameters = new LoggerConfigurationParameters(_formatParameters, _parameterSerializer);
            
            foreach (var destination in logDestinations.AsSpan())
            {
                destination.Initialize(configurationParameters);
            }

            return logDestinations;
        }
        
        private static IMessageFormatParser GetParser()
        {
            return new MessageFormatParserCached(new MessageFormatParser());
        }
    }
}