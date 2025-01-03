using System.Collections.Generic;
using System.Linq;
using Openmygame.Logger.Builders;
using Openmygame.Logger.Configuration.Attributes;
using Openmygame.Logger.Configuration.Base;
using Openmygame.Logger.Configuration.Logger.Destinations;
using Openmygame.Logger.Parameters.Message.Base;
using UnityEngine;

namespace Openmygame.Logger.Configuration.Logger
{
    [LoggerConfigMetadata("LoggerConfig", "Create logger config", orderInEditor: 1)]
    public class LoggerConfig : LoggerConfigBase
    {
        [SerializeField] private bool _isEnabled = true;
        [SerializeField] private bool _isExtractStacktrace = LoggerConfigurationData.IsExtractStacktrace;

        [SerializeReference, SerializeReferenceDropdown]
        private IMessageFormatParameter[] _messageFormatParameters;
        
        [SerializeReference, SerializeReferenceDropdown] 
        private List<LoggerDestinationBuilder> _destinationBuilders;

        public static LoggerConfig Load(string resourcePath = "LoggerUnity/LoggerConfig")
        {
            var config = Resources.Load<LoggerConfig>(resourcePath);

            if (config == null)
            {
                config = CreateInstance<LoggerConfig>();
                config.SetupDefaults();
            }

            return config;
        }
        
        public void Build(LoggerBuilder loggerBuilder)
        {
            loggerBuilder.SetEnabled(_isEnabled);
            loggerBuilder.SetIsExtractStacktrace(_isExtractStacktrace);
            AddMessageParameters(loggerBuilder);
            BuildDestinations(loggerBuilder);
        }

        public override void SetupDefaults()
        {
            _messageFormatParameters = LoggerConfigurationData.MessageFormatParameters
                .Select(x => x.Value)
                .ToArray();
            
            _destinationBuilders = new List<LoggerDestinationBuilder>();
        }

        private void BuildDestinations(LoggerBuilder loggerBuilder)
        {
            foreach (var destinationBuilder in _destinationBuilders.Where(x => x.CanBuild()))
            {
                destinationBuilder.Build(loggerBuilder);
            }
        }

        private void AddMessageParameters(LoggerBuilder loggerBuilder)
        {
            if (_messageFormatParameters == null || _messageFormatParameters.Length == 0)
            {
                return;
            }
            
            foreach (var messageFormatParameter in _messageFormatParameters)
            {
                loggerBuilder.AddMessageFormatParameter(messageFormatParameter);
            }
        }
    }
}