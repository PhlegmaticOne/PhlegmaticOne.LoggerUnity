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

        public Color GetLogParameterColor(in ReadOnlySpan<char> parameterKey, in ReadOnlySpan<char> renderedValue)
        {
            if (parameterKey.IsEmpty)
            {
                return LoggerStaticData.DefaultLogTextColor;
            }
            
            if (parameterKey == LogFormatParameterLogLevel.KeyParameter)
            {
                return GetLogLevelColor(renderedValue);
            }
            
            return _logParameterColorsMap
                .TryGetValue(parameterKey.ToString(), out var color) ? color : LoggerStaticData.DefaultLogTextColor;
        }

        private Color GetLogLevelColor(in ReadOnlySpan<char> renderedValue)
        {
            if (_logLevelColorsMap.TryGetValue(renderedValue.ToString(), out var color))
            {
                return color;
            }

            return LoggerStaticData.DefaultLogTextColor;
        }
    }
}