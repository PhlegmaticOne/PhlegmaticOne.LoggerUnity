using Openmygame.Logger.Configuration.Tagging.Base;

namespace Openmygame.Logger.Configuration.Tagging
{
    internal sealed class LoggerTaggingConfigDefault : ILoggerTaggingConfig
    {
        public string DefaultTagFormat => LoggerConfigurationData.TagFormat;
        public string DefaultSubsystemFormat => LoggerConfigurationData.SubsystemFormat;
    }
}