using System;
using Openmygame.Logger.Builders;
using Openmygame.Logger.Configuration.Attributes;
using Openmygame.Logger.Configuration.Colors;
using Openmygame.Logger.Configuration.Logger.Destinations.Platforms;
using Openmygame.Logger.Destinations.UnityDebug;
using Openmygame.Logger.Destinations.UnityDebug.Exceptions;
using Openmygame.Logger.Destinations.UnityDebug.Extensions;
using UnityEngine;

namespace Openmygame.Logger.Configuration.Logger.Destinations.UnityDebug
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
        [Tooltip("Если не указан, то используется LogWrapException")]
        [SerializeReference, SerializeReferenceDropdown] private IUnityDebugExceptionFunc _exceptionFunc;

        protected override LoggerPlatform Platform => LoggerPlatform.Editor;

        public override void Build(LoggerBuilder loggerBuilder)
        {
            loggerBuilder.LogToUnityDebug(config =>
            {
                SetupConfigurationBase(config);
                config.MessagePartMaxSize = _maxMessagePartSize;
                config.MessagePartFormat = _messagePartFormat;
                config.IsUnityStacktraceEnabled = _isUnityStacktraceEnabled;
                config.CustomDebugExceptionFunc = _exceptionFunc;
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