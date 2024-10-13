using System;
using OpenMyGame.LoggerUnity.Attributes;
using OpenMyGame.LoggerUnity.Configuration.Logger.Destinations.Platforms;
using OpenMyGame.LoggerUnity.Destinations.IOS.Extensions;

namespace OpenMyGame.LoggerUnity.Configuration.Logger.Destinations.IOS
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