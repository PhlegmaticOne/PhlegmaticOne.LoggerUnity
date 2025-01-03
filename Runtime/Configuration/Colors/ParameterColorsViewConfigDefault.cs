using System;
using System.Collections.Generic;
using System.Linq;
using Openmygame.Logger.Configuration.Colors.Base;
using Openmygame.Logger.Configuration.Colors.Static;
using Openmygame.Logger.Infrastructure.Extensions;
using Openmygame.Logger.Parameters.Log;
using UnityEngine;
using LogLevel = Openmygame.Logger.Messages.LogLevel;

namespace Openmygame.Logger.Configuration.Colors
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

        public Color GetSubsystemColor()
        {
            return UnityDebugColorsStaticData.DefaultSubsystemColor;
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