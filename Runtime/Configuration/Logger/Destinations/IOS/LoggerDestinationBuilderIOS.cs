using System;
using Openmygame.Logger.Builders;
using Openmygame.Logger.Configuration.Attributes;
using Openmygame.Logger.Configuration.Logger.Destinations.Platforms;
using Openmygame.Logger.Destinations.IOS.Extensions;

namespace Openmygame.Logger.Configuration.Logger.Destinations.IOS
{
    [Serializable]
    [SerializeReferenceDropdownName("IOS")]
    public class LoggerDestinationBuilderIOS : LoggerDestinationBuilder
    {
        protected override LoggerPlatform Platform => LoggerPlatform.Ios;
        
        public override void Build(LoggerBuilder loggerBuilder)
        {
            loggerBuilder.LogToIOS(SetupConfigurationBase);
        }
    }
}