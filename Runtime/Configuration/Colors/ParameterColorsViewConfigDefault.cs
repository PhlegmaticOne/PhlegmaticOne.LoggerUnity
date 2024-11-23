using System;
using System.Collections.Generic;
using System.Linq;
using OpenMyGame.LoggerUnity.Configuration.Colors.Base;
using OpenMyGame.LoggerUnity.Configuration.Colors.Static;
using OpenMyGame.LoggerUnity.Extensions;
using OpenMyGame.LoggerUnity.Parameters.Log;
using UnityEngine;
using LogLevel = OpenMyGame.LoggerUnity.Messages.LogLevel;

namespace OpenMyGame.LoggerUnity.Configuration.Colors
{
    internal class ParameterColorsViewConfigDefault : IParameterColorsViewConfig
    {
        private readonly Dictionary<string, Color> _logParameterColorsMap;
        private readonly Dictionary<Type, Color> _messageParameterColorsMap;
        private readonly Dictionary<string, Color> _logLevelColorsMap;

        public ParameterColorsViewConfigDefault()
        {
            _messageParameterColorsMap = UnityDebugColorsStaticData.MessageParameterColorsMap
                .ToDictionary(x => x.Key.PropertyType, x => x.Value);
            _logParameterColorsMap = UnityDebugColorsStaticData.LogParameterColorsMap
                .ToDictionary(x => x.Key.Key, x => x.Value);
            _logLevelColorsMap = UnityDebugColorsStaticData.LogLevelColorsMap;
        }
        
        public Color GetTagColor(string tag)
        {
            return LoggerConfigurationData.DefaultLogTextColor;
        }

        public Color GetMessageParameterColor(object parameter)
        {
            if (parameter is null)
            {
                return LoggerConfigurationData.DefaultLogTextColor;
            }
            
            return _messageParameterColorsMap
                .TryGetValue(parameter.GetType(), out var color) ? color : LoggerConfigurationData.DefaultLogTextColor;
        }

        public Color GetLogParameterColor(string parameterKey, object value)
        {
            if (string.IsNullOrEmpty(parameterKey))
            {
                return LoggerConfigurationData.DefaultLogTextColor;
            }
            
            if (parameterKey.Equals(LogFormatParameterLogLevel.KeyParameter, StringComparison.OrdinalIgnoreCase))
            {
                return _logLevelColorsMap[((LogLevel)value).ToStringCache()];
            }
            
            return _logParameterColorsMap.TryGetValue(parameterKey, out var color) ? color : LoggerConfigurationData.DefaultLogTextColor;
        }
    }
}