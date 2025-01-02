using System;
using System.Linq;
using Openmygame.Logger.Configuration.Attributes;
using Openmygame.Logger.Configuration.Base;
using Openmygame.Logger.Configuration.Colors.Base;
using Openmygame.Logger.Configuration.Colors.Models;
using Openmygame.Logger.Configuration.Colors.Static;
using Openmygame.Logger.Messages;
using Openmygame.Logger.Parameters.Log;
using UnityEngine;

namespace Openmygame.Logger.Configuration.Colors
{
    [LoggerConfigMetadata("ParameterColorsViewConfig", "Create parameter colors view config", orderInEditor: 1)]
    public class ParameterColorsViewConfig : LoggerConfigBase, IParameterColorsViewConfig
    {
        [SerializeField, OverrideElementNames] private LogParameterColorConfigData[] _logParameterColors;
        [SerializeField, OverrideElementNames] private MessageParameterColorConfigData[] _messageParameterColors;
        [SerializeField, OverrideElementNames] private LogLevelColorConfigData[] _logLevelColors;
        [SerializeField, OverrideElementNames] private TagColorConfigData[] _tagColors;

        public static IParameterColorsViewConfig Load(string resourcePath = "LoggerUnity/ParameterColorsViewConfig")
        {
            var config = Resources.Load<ParameterColorsViewConfig>(resourcePath);
            return config == null ? new ParameterColorsViewConfigDefault() : config;
        }

        public override void SetupDefaults()
        {
            _tagColors = Array.Empty<TagColorConfigData>();
            
            _logParameterColors = UnityDebugColorsStaticData.LogParameterColorsMap
                .Select(x => new LogParameterColorConfigData(x.Key, x.Value))
                .ToArray();

            _messageParameterColors = UnityDebugColorsStaticData.MessageParameterColorsMap
                .Select(x => new MessageParameterColorConfigData(x.Key, x.Value))
                .ToArray();

            _logLevelColors = UnityDebugColorsStaticData.LogLevelColorsMap
                .Select(x => new LogLevelColorConfigData(Enum.Parse<LogLevel>(x.Key), x.Value))
                .ToArray();
        }

        public Color GetTagColor(string tag)
        {
            var tagColorData = Array.Find(_tagColors, x => x.Tag.Equals(tag, StringComparison.OrdinalIgnoreCase));
            return tagColorData.ContainsData() ? tagColorData.Color : LoggerConfigurationData.DefaultLogTextColor;
        }

        public Color GetMessageParameterColor(object parameter)
        {
            var parameterTypeName = parameter.GetType();
            var parameterColor = Array.Find(_messageParameterColors, x => x.ParameterType == parameterTypeName);
            return parameterColor.ContainsData() ? parameterColor.Color : LoggerConfigurationData.DefaultLogTextColor;
        }

        public Color GetLogParameterColor(string parameterKey, object parameterValue)
        {
            if (parameterKey.Equals(LogFormatParameterLogLevel.KeyParameter, StringComparison.OrdinalIgnoreCase))
            {
                var logLevel = (LogLevel)parameterValue;
                return Array.Find(_logLevelColors, x => x.LogLevel == logLevel).Color;
            }

            if (!TryGetLogParameterColor(parameterKey, out var result))
            {
                return LoggerConfigurationData.DefaultLogTextColor;
            }

            return result.Color;
        }

        private bool TryGetLogParameterColor(string parameterKey, out LogParameterColorConfigData result)
        {
            foreach (var configData in _logParameterColors.AsSpan())
            {
                if (configData.ParameterEquals(parameterKey))
                {
                    result = configData;
                    return true;
                }
            }

            result = new LogParameterColorConfigData();
            return false;
        }
    }
}