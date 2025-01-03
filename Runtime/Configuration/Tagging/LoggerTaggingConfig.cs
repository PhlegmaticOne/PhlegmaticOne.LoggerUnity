using Openmygame.Logger.Configuration.Attributes;
using Openmygame.Logger.Configuration.Base;
using Openmygame.Logger.Configuration.Tagging.Base;
using UnityEngine;

namespace Openmygame.Logger.Configuration.Tagging
{
    [LoggerConfigMetadata("LoggerTaggingConfig", "Create logger tagging config", orderInEditor: 0)]
    internal sealed class LoggerTaggingConfig : LoggerConfigBase, ILoggerTaggingConfig
    {
        [SerializeField] private string _defaultTagFormat = LoggerConfigurationData.TagFormat;
        [SerializeField] private string _defaultSubsystemFormat = LoggerConfigurationData.SubsystemFormat;

        public static ILoggerTaggingConfig Load(string resourcePath = "LoggerUnity/LoggerTaggingConfig")
        {
            var config = Resources.Load<LoggerTaggingConfig>(resourcePath);
            return config == null ? new LoggerTaggingConfigDefault() : config;
        }
        
        public override void SetupDefaults()
        {
            _defaultTagFormat = LoggerConfigurationData.TagFormat;
            _defaultSubsystemFormat = LoggerConfigurationData.SubsystemFormat;
        }

        public string DefaultTagFormat => _defaultTagFormat;

        public string DefaultSubsystemFormat => _defaultSubsystemFormat;
    }
}