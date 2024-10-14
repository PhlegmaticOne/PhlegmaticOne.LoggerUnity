using System;
using System.Collections.Generic;
using System.Linq;
using OpenMyGame.LoggerUnity.Attributes;
using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Configuration.Base;
using OpenMyGame.LoggerUnity.Configuration.Colors.Base;
using OpenMyGame.LoggerUnity.Configuration.Colors.Models;
using OpenMyGame.LoggerUnity.Configuration.Colors.Static;
using OpenMyGame.LoggerUnity.Messages;
using OpenMyGame.LoggerUnity.Parameters.Log;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.Configuration.Colors
{
    [LoggerConfigMetadata("ParameterColorsViewConfig", "Create parameter colors view config", orderInEditor: 1)]
    public class ParameterColorsViewConfig : LoggerConfigBase, IParameterColorsViewConfig
    {
        [SerializeField, OverrideElementNames] private List<LogParameterColorConfigData> _logParameterColors;
        [SerializeField, OverrideElementNames] private List<MessageParameterColorConfigData> _messageParameterColors;
        [SerializeField, OverrideElementNames] private List<LogLevelColorConfigData> _logLevelColors;
        [SerializeField, OverrideElementNames] private List<TagColorConfigData> _tagColors;

        public static IParameterColorsViewConfig Load(string resourcePath = "LoggerUnity/ParameterColorsViewConfig")
        {
            var config = Resources.Load<ParameterColorsViewConfig>(resourcePath);
            return config == null ? new ParameterColorsViewConfigDefault() : config;
        }

        public override void SetupDefaults()
        {
            _tagColors = new List<TagColorConfigData>();
            
            _logParameterColors = UnityDebugColorsStaticData.LogParameterColorsMap
                .Select(x => new LogParameterColorConfigData(x.Key, x.Value))
                .ToList();

            _messageParameterColors = UnityDebugColorsStaticData.MessageParameterColorsMap
                .Select(x => new MessageParameterColorConfigData(x.Key, x.Value))
                .ToList();

            _logLevelColors = UnityDebugColorsStaticData.LogLevelColorsMap
                .Select(x => new LogLevelColorConfigData(Enum.Parse<LogLevel>(x.Key), x.Value))
                .ToList();
        }

        public Color GetTagColor(string tag)
        {
            var tagColorData = _tagColors.Find(x => x.Tag.Equals(tag, StringComparison.OrdinalIgnoreCase));
            return tagColorData.ContainsData() ? tagColorData.Color : LoggerStaticData.DefaultLogTextColor;
        }

        public Color GetMessageParameterColor(object parameter)
        {
            var parameterTypeName = parameter.GetType();
            var parameterColor = _messageParameterColors.Find(x => x.ParameterType == parameterTypeName);
            return parameterColor.ContainsData() ? parameterColor.Color : LoggerStaticData.DefaultLogTextColor;
        }

        public Color GetLogParameterColor(in ReadOnlySpan<char> parameterKey, in ReadOnlySpan<char> renderedValue)
        {
            if (parameterKey.Equals(LogFormatParameterLogLevel.KeyParameter, StringComparison.OrdinalIgnoreCase))
            {
                return GetLogLevelColor(renderedValue);
            }

            if (!TryGetLogParameterColor(parameterKey, out var result))
            {
                return LoggerStaticData.DefaultLogTextColor;
            }

            return result.Color;
        }

        private bool TryGetLogParameterColor(in ReadOnlySpan<char> parameterKey, out LogParameterColorConfigData result)
        {
            foreach (var configData in _logParameterColors)
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

        private Color GetLogLevelColor(in ReadOnlySpan<char> logLevelValue)
        {
            var logLevel = LogLevelHelper.ParseFromSpan(logLevelValue);

            foreach (var logLevelColorData in _logLevelColors)
            {
                if (logLevelColorData.LogLevel == logLevel)
                {
                    return logLevelColorData.Color;
                }
            }

            return LoggerStaticData.DefaultLogTextColor;
        }
    }
}