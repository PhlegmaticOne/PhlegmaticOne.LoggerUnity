using Openmygame.Logger.Configuration.Tagging;
using Openmygame.Logger.Configuration.Tagging.Base;

namespace Openmygame.Logger.Messages.Tagging
{
    internal static class LogTagFormatsProvider
    {
        private static ILoggerTaggingConfig Config;
        
        public static string Tag()
        {
            Config ??= LoggerTaggingConfig.Load();
            return Config.DefaultTagFormat;
        }

        public static string Subsystem()
        {
            Config ??= LoggerTaggingConfig.Load();
            return Config.DefaultSubsystemFormat;
        }
    }
}