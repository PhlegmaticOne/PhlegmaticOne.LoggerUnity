using System;
using System.Collections.Generic;
using System.Linq;
using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Destinations.UnityDebug.Colors.Static;
using OpenMyGame.LoggerUnity.Destinations.UnityDebug.Colors.ViewConfig.Base;
using OpenMyGame.LoggerUnity.Destinations.UnityDebug.Colors.ViewConfig.Models;
using OpenMyGame.LoggerUnity.Messages;
using OpenMyGame.LoggerUnity.Parameters.Log;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.Destinations.UnityDebug.Colors.ViewConfig
{
    public class ParameterColorsViewConfig : ScriptableObject, IParameterColorsViewConfig
    {
        [SerializeField] private List<KeyColorConfigData> _logParameterColors;
        [SerializeField] private List<KeyColorConfigData> _parametersColorsByType;
        [SerializeField] private List<LogLevelColorConfigData> _logLevelColors;
        [SerializeField] private List<KeyColorConfigData> _tagColors;

        public static IParameterColorsViewConfig Load(string resourcePath = "LoggerUnity/ParameterColorsViewConfig")
        {
            var config = Resources.Load<ParameterColorsViewConfig>(resourcePath);
            return config == null ? new ParameterColorsViewConfigDefault() : config;
        }

        internal void SetupDefaults()
        {
            _tagColors = new List<KeyColorConfigData>();
            
            _logParameterColors = UnityDebugColorsStaticData.LogParameterColorsMap
                .Select(x => new KeyColorConfigData(x.Key, x.Value))
                .ToList();

            _parametersColorsByType = UnityDebugColorsStaticData.MessageParameterColorsMap
                .Select(x => new KeyColorConfigData(x.Key, x.Value))
                .ToList();

            _logLevelColors = UnityDebugColorsStaticData.LogLevelColorsMap
                .Select(x => new LogLevelColorConfigData(Enum.Parse<LogLevel>(x.Key), x.Value))
                .ToList();
        }

        public Color GetTagColor(string tag)
        {
            var tagColorData = _tagColors.Find(x => x.Key.Equals(tag, StringComparison.OrdinalIgnoreCase));
            return tagColorData.ContainsData() ? tagColorData.Color : LoggerStaticData.DefaultLogTextColor;
        }

        public Color GetMessageParameterColor(object parameter)
        {
            var parameterTypeName = parameter.GetType().Name;
            
            var parameterColor = _parametersColorsByType.Find(x =>
                x.Key.Contains(parameterTypeName, StringComparison.OrdinalIgnoreCase));

            return parameterColor.ContainsData() ? parameterColor.Color : LoggerStaticData.DefaultLogTextColor;
        }

        public Color GetLogParameterColor(string parameterKey, in ReadOnlySpan<char> renderedValue)
        {
            if (renderedValue.Equals(LogFormatParameterLogLevel.KeyParameter, StringComparison.OrdinalIgnoreCase))
            {
                return GetLogLevelColor(renderedValue);
            }
            
            var parameterColor = _logParameterColors.Find(x =>
                x.Key.Contains(parameterKey, StringComparison.OrdinalIgnoreCase));

            return parameterColor.ContainsData() ? parameterColor.Color : LoggerStaticData.DefaultLogTextColor;
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