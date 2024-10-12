using System;
using OpenMyGame.LoggerUnity.Attributes;
using OpenMyGame.LoggerUnity.Configuration.Colors;
using OpenMyGame.LoggerUnity.Destinations.UnityDebug;
using OpenMyGame.LoggerUnity.Destinations.UnityDebug.Extensions;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.Configuration.Logger.Destinations.UnityDebug
{
    [Serializable]
    [SerializeReferenceDropdownName("Unity Debug")]
    public class LoggerDestinationBuilderUnityDebug : LoggerDestinationBuilder
    {
        [SerializeField, Range(0, 100000000)] 
        private int _maxMessagePartSize = UnityDebugLogStaticData.MessagePartMaxSize;
        
        [SerializeField] private string _messagePartFormat = UnityDebugLogStaticData.MessagePartFormat;
        [SerializeField] private bool _isUnityStacktraceEnabled = UnityDebugLogStaticData.IsUnityStacktraceEnabled;
        [SerializeField] private bool _isColorizeParameters;
        [Tooltip("Если конфиг не указан, то используется дефолтный конфиг")]
        [SerializeField] private ParameterColorsViewConfig _customViewConfig;
        
        public override void Build(LoggerBuilder loggerBuilder)
        {
            loggerBuilder.LogToUnityDebug(config =>
            {
                SetupConfigurationBase(config);
                config.MessagePartMaxSize = _maxMessagePartSize;
                config.MessagePartFormat = _messagePartFormat;
                config.IsUnityStacktraceEnabled = _isUnityStacktraceEnabled;
                EnableColorizeParameters(config);
            });
        }

        private void EnableColorizeParameters(UnityDebugLogConfiguration config)
        {
            if (!_isColorizeParameters)
            {
                return;
            }
            
            if (_customViewConfig != null)
            {
                config.ColorizeParameters(_customViewConfig);
            }
            else
            {
                config.ColorizeParameters();
            }
        }
    }
}