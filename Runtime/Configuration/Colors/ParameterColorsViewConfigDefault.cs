using System;
using System.Collections.Generic;
using System.Linq;
using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Configuration.Colors.Base;
using OpenMyGame.LoggerUnity.Configuration.Colors.Static;
using OpenMyGame.LoggerUnity.Parameters.Log;
using UnityEngine;

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
            return LoggerStaticData.DefaultLogTextColor;
        }

        public Color GetMessageParameterColor(object parameter)
        {
            if (parameter is null)
            {
                return LoggerStaticData.DefaultLogTextColor;
            }
            
            return _messageParameterColorsMap
                .TryGetValue(parameter.GetType(), out var color) ? color : LoggerStaticData.DefaultLogTextColor;
        }

        public Color GetLogParameterColor(string parameterKey, object value)
        {
            if (string.IsNullOrEmpty(parameterKey))
            {
                return LoggerStaticData.DefaultLogTextColor;
            }
            
            if (parameterKey.Equals(LogFormatParameterLogLevel.KeyParameter, StringComparison.OrdinalIgnoreCase))
            {
                return _logLevelColorsMap[value.ToString()];
            }
            
            return _logParameterColorsMap.TryGetValue(parameterKey, out var color) ? color : LoggerStaticData.DefaultLogTextColor;
        }
    }
}