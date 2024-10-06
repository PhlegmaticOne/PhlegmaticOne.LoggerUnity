using System;
using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Destinations.UnityDebug.Colors;
using OpenMyGame.LoggerUnity.Destinations.UnityDebug.Colors.ViewConfig;
using OpenMyGame.LoggerUnity.Destinations.UnityDebug.Colors.ViewConfig.Base;

namespace OpenMyGame.LoggerUnity.Destinations.UnityDebug
{
    public class UnityDebugLogConfiguration : LogConfiguration
    {
        private int _messagePartMaxSize;
        private string _messagePartFormat;
        
        public UnityDebugLogConfiguration()
        {
            MessagePartMaxSize = UnityDebugLogStaticData.MessagePartMaxSize;
            MessagePartFormat = UnityDebugLogStaticData.MessagePartFormat;
            IsUnityStacktraceEnabled = UnityDebugLogStaticData.IsUnityStacktraceEnabled;
        }

        public bool IsUnityStacktraceEnabled { get; set; }

        public int MessagePartMaxSize
        {
            get => _messagePartMaxSize;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Message part max size cannot be less than zero", nameof(MessagePartMaxSize));
                }

                _messagePartMaxSize = value;
            }
        }

        public string MessagePartFormat
        {
            get => _messagePartFormat;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Message part format cannot be an empty string", nameof(MessagePartFormat));
                }

                _messagePartFormat = value;
            }
        }

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