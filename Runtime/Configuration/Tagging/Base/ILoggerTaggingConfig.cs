namespace Openmygame.Logger.Configuration.Tagging.Base
{
    internal interface ILoggerTaggingConfig
    {
        string DefaultTagFormat { get; }
        string DefaultSubsystemFormat { get; }
    }
}