using System;
using System.Collections.Generic;
using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Configuration;
using OpenMyGame.LoggerUnity.Configuration.Logger;
using OpenMyGame.LoggerUnity.Configuration.Logger.Destinations.Platforms;
using OpenMyGame.LoggerUnity.Messages.Factories;
using OpenMyGame.LoggerUnity.Messages.Tagging;
using OpenMyGame.LoggerUnity.Parameters.Message.Base;
using OpenMyGame.LoggerUnity.Parameters.Message.Serializing;
using OpenMyGame.LoggerUnity.Parsing;
using OpenMyGame.LoggerUnity.Parsing.Base;

namespace OpenMyGame.LoggerUnity.Builders
{
    public class LoggerBuilder
    {
        private readonly List<ILogDestination> _loggerDestinations;
        private readonly IMessageFormatParameterSerializer _parameterSerializer;
        private readonly Dictionary<Type, IMessageFormatParameter> _formatParameters;

        private bool _isExtractStackTraces;
        private string _tagFormat;
        private bool _isEnabled;

        public LoggerBuilder()
        {
            _loggerDestinations = new List<ILogDestination>();
            _tagFormat = LoggerConfigurationData.TagFormat;
            _isEnabled = LoggerConfigurationData.IsEnabled;
            _isExtractStackTraces = LoggerConfigurationData.IsExtractStacktrace;
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

        public LoggerBuilder SetTagFormat(string tagFormat)
        {
            _tagFormat = tagFormat;
            return this;
        }

        public LoggerBuilder SetIsExtractStackTraces(bool isExtractStackTraces)
        {
            _isExtractStackTraces = isExtractStackTraces;
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
            
            if (!configuration.Platform.HasFlag(LoggerPlatformProvider.GetPlatform()))
            {
                return this;
            }
            
            _loggerDestinations.Add(new TDestination
            {
                Configuration = configuration
            });
            
            return this;
        }

        public ILogger CreateLogger()
        {
            LogTag.Format.UpdateFormat(_tagFormat);
            
            return new Logger(GetInitializedDestinations(), GetParser(), GetMessageFactory(), _isExtractStackTraces)
            {
                IsEnabled = _isEnabled
            };
        }

        private ILogDestination[] GetInitializedDestinations()
        {
            var destinations = _loggerDestinations.ToArray();
            var configurationParameters = new LoggerConfigurationParameters(_formatParameters, _parameterSerializer);
            
            foreach (var destination in destinations.AsSpan())
            {
                destination.Initialize(configurationParameters);
            }

            return destinations;
        }
        
        private static IMessageFormatParser GetParser()
        {
            return new MessageFormatParserCached(new MessageFormatParser());
        }

        private static ILogMessageFactory GetMessageFactory()
        {
            return new LogMessageFactory();
        }
    }
}