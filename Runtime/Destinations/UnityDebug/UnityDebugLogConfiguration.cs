using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Destinations.UnityDebug.Colors;
using OpenMyGame.LoggerUnity.Destinations.UnityDebug.Colors.ViewConfig;
using OpenMyGame.LoggerUnity.Destinations.UnityDebug.Colors.ViewConfig.Base;

namespace OpenMyGame.LoggerUnity.Destinations.UnityDebug
{
    public class UnityDebugLogConfiguration : LogConfiguration
    {
        public UnityDebugLogConfiguration()
        {
            MessagePartMaxSize = UnityDebugLogStaticData.MessagePartMaxSize;
            MessagePartFormat = UnityDebugLogStaticData.MessagePartFormat;
            IsUnityStacktraceEnabled = UnityDebugLogStaticData.IsUnityStacktraceEnabled;
        }
        
        public int MessagePartMaxSize { get; set; }
        public string MessagePartFormat { get; set; }
        public bool IsUnityStacktraceEnabled { get; set; }

        public void ColorizeParameters()
        {
            ColorizeParameters(new ParameterColorsViewConfigDefault());
        }
        
        public void ColorizeParameters(IParameterColorsViewConfig colorsViewConfig)
        {
            SetLogParameterPostRenderProcessor(new LogParameterPostRenderProcessorColorize(colorsViewConfig));
            SetMessageParameterPostRenderProcessor(new MessageParameterPostRenderProcessorColorize(colorsViewConfig));
        }
    }
}