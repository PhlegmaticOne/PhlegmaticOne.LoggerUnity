using System;
using System.Collections.Generic;
using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Destinations.UnityDebug.Colors.Static;
using OpenMyGame.LoggerUnity.Destinations.UnityDebug.Colors.ViewConfig.Base;
using OpenMyGame.LoggerUnity.Parameters.Log;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.Destinations.UnityDebug.Colors.ViewConfig
{
    internal class ParameterColorsViewConfigDefault : IParameterColorsViewConfig
    {
        private readonly Dictionary<string, Color> _logParameterColorsMap;
        private readonly Dictionary<string, Color> _messageParameterColorsMap;
        private readonly Dictionary<string, Color> _logLevelColorsMap;

        public ParameterColorsViewConfigDefault()
        {
            _messageParameterColorsMap = UnityDebugColorsStaticData.MessageParameterColorsMap;
            _logLevelColorsMap = UnityDebugColorsStaticData.LogLevelColorsMap;
            _logParameterColorsMap = UnityDebugColorsStaticData.LogParameterColorsMap;
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
            
            var parameterName = parameter.GetType().Name;
            
            return _messageParameterColorsMap
                .TryGetValue(parameterName, out var color) ? color : LoggerStaticData.DefaultLogTextColor;
        }

        public Color GetLogParameterColor(string parameterKey, in ReadOnlySpan<char> renderedValue)
        {
            if (string.IsNullOrEmpty(parameterKey))
            {
                return LoggerStaticData.DefaultLogTextColor;
            }
            
            if (parameterKey == LogFormatParameterLogLevel.KeyParameter)
            {
                return GetLogLevelColor(renderedValue);
            }
            
            return _logParameterColorsMap
                .TryGetValue(parameterKey, out var color) ? color : LoggerStaticData.DefaultLogTextColor;
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