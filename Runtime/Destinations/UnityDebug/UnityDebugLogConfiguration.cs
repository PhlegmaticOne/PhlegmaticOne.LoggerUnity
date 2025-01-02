﻿using System;
using Openmygame.Logger.Base;
using Openmygame.Logger.Configuration.Colors;
using Openmygame.Logger.Configuration.Colors.Base;
using Openmygame.Logger.Configuration.Logger.Destinations.Platforms;
using Openmygame.Logger.Destinations.UnityDebug.Colors;

namespace Openmygame.Logger.Destinations.UnityDebug
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
            Platform = LoggerPlatform.Editor | LoggerPlatform.Android | LoggerPlatform.Ios;
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
            SetMessageParameterPostRenderer(new MessageParameterProcessorColorize(colorsViewConfig));
            SetLogParameterPostRenderer(new LogParameterProcessorColorize(colorsViewConfig));
        }
    }
}