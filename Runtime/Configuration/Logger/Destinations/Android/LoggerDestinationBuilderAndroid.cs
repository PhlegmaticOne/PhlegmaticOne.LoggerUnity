using System;
using OpenMyGame.LoggerUnity.Attributes;
using OpenMyGame.LoggerUnity.Configuration.Logger.Destinations.Platforms;
using OpenMyGame.LoggerUnity.Destinations.Android.Extensions;

namespace OpenMyGame.LoggerUnity.Configuration.Logger.Destinations.Android
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