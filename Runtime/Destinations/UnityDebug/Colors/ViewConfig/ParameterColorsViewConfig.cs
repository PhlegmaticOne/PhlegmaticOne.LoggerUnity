using System;
using System.Collections.Generic;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.Destinations.UnityDebug.Colors.ViewConfig
{
    public class ParameterColorsViewConfig : ScriptableObject, IParameterColorsViewConfig
    {
        [SerializeField] private List<KeyColorConfigData> _logParameterColors;
        [SerializeField] private List<KeyColorConfigData> _parametersColorsByType;
        [SerializeField] private List<KeyColorConfigData> _knownTagColors;

        public static IParameterColorsViewConfig Load()
        {
            return Load("LoggerUnity/ParameterColorsViewConfig");
        }
        
        public static IParameterColorsViewConfig Load(string resourcePath)
        {
            var config = Resources.Load<ParameterColorsViewConfig>(resourcePath);
            return config == null ? new ParameterColorsViewConfigStaticWhite() : config;
        }

        public Color GetTagColor(string tag)
        {
            return TryGetKnownTagColor(tag, out var color) ? color : Color.white;
        }

        public Color GetMessageParameterColor(object parameter)
        {
            var parameterTypeName = parameter.GetType().Name;
            
            var parameterColor = _parametersColorsByType.Find(x =>
                x.Key.Contains(parameterTypeName, StringComparison.OrdinalIgnoreCase));

            return parameterColor.ContainsData() ? parameterColor.Color : Color.white;
        }

        public Color GetLogParameterColor(string parameterKey)
        {
            var parameterColor = _logParameterColors.Find(x =>
                x.Key.Contains(parameterKey, StringComparison.OrdinalIgnoreCase));

            return parameterColor.ContainsData() ? parameterColor.Color : Color.white;
        }

        private bool TryGetKnownTagColor(string tag, out Color color)
        {
            var tagData = _knownTagColors.Find(x => x.Key.Equals(tag, StringComparison.OrdinalIgnoreCase));

            if (string.IsNullOrEmpty(tagData.Key))
            {
                color = Color.clear;
                return false;
            }

            color = tagData.Color;
            return true;
        }
    }
}