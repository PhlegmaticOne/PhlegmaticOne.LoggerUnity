using System;
using OpenMyGame.LoggerUnity.Attributes;
using OpenMyGame.LoggerUnity.Destinations.Android.Extensions;

namespace OpenMyGame.LoggerUnity.Configuration.Logger.Destinations.Android
{
    [Serializable]
    [SerializeReferenceDropdownName("Android Log")]
    public class LoggerDestinationBuilderAndroid : LoggerDestinationBuilder
    {
        public override void Build(LoggerBuilder loggerBuilder)
        {
            loggerBuilder.LogToAndroidLog(SetupConfigurationBase);
        }
    }
}