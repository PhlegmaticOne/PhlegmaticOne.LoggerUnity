using System.Collections.Generic;
using System.Linq;
using OpenMyGame.LoggerUnity.Builders;
using OpenMyGame.LoggerUnity.Configuration.Attributes;
using OpenMyGame.LoggerUnity.Configuration.Base;
using OpenMyGame.LoggerUnity.Configuration.Logger.Destinations;
using OpenMyGame.LoggerUnity.Parameters.Message.Base;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.Configuration.Logger
{
    [LoggerConfigMetadata("LoggerConfig", "Create logger config", orderInEditor: 0)]
    public class LoggerConfig : LoggerConfigBase
    {
        [SerializeField] private bool _isEnabled = true;
        [SerializeField] private bool _isExtractStacktraces = LoggerConfigurationData.IsExtractStacktrace;
        [SerializeField] private string _tagFormat = LoggerConfigurationData.TagFormat;

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
            loggerBuilder.SetIsExtractStackTraces(_isExtractStacktraces);
            loggerBuilder.SetTagFormat(_tagFormat);
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