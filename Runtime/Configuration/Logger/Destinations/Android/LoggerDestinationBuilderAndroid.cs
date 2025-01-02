using System;
using Openmygame.Logger.Builders;
using Openmygame.Logger.Configuration.Attributes;
using Openmygame.Logger.Configuration.Logger.Destinations.Platforms;
using Openmygame.Logger.Destinations.Android.Extensions;

namespace Openmygame.Logger.Configuration.Logger.Destinations.Android
{
    [Serializable]
    [SerializeReferenceDropdownName("Android Log")]
    public class LoggerDestinationBuilderAndroid : LoggerDestinationBuilder
    {
        protected override LoggerPlatform Platform => LoggerPlatform.Android;

        public override void Build(LoggerBuilder loggerBuilder)
        {
            loggerBuilder.LogToAndroidLog(SetupConfigurationBase);
        }
    }
}