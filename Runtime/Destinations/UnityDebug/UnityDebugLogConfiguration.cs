using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Destinations.UnityDebug.Colors;
using OpenMyGame.LoggerUnity.Destinations.UnityDebug.Colors.ViewConfig;

namespace OpenMyGame.LoggerUnity.Destinations.UnityDebug
{
    public class UnityDebugLogConfiguration : LogConfiguration
    {
        public int MessagePartMaxSize { get; set; } = int.MaxValue;
        public bool IsUnityStacktraceEnabled { get; set; } = true;

        public void ColorizeParameters()
        {
            ColorizeParameters(new ParameterColorsViewConfigStaticWhite());
        }
        
        public void ColorizeParameters(IParameterColorsViewConfig colorsViewConfig)
        {
            SetLogParameterPostRenderProcessor(new LogParameterPostRenderProcessorColorize(colorsViewConfig));
            SetMessageParameterPostRenderProcessor(new MessageParameterPostRenderProcessorColorize(colorsViewConfig));
        }
    }
}