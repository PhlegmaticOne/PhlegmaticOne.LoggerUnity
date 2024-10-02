using System;
using System.Collections.Generic;
using OpenMyGame.LoggerUnity.Tagging;
using UnityEngine;
using Random = UnityEngine.Random;

namespace OpenMyGame.LoggerUnity.Parameters.Processors.Colors.ViewConfig
{
    public class ParameterColorsViewConfig : ScriptableObject, IParameterColorsViewConfig
    {
        [SerializeField] private Color _defaultParameterColor;
        [SerializeField] private List<KeyColorConfigData> _parametersColorsByType;
        [SerializeField] private List<KeyColorConfigData> _knownTagColors;
        [SerializeField] private Color[] _unknownTagColors;

        public static IParameterColorsViewConfig Load()
        {
            var config = Resources.Load<ParameterColorsViewConfig>("LoggerUnity/ParameterColorsViewConfig");
            return config == null ? new ParameterColorsViewConfigRandom() : config;
        }

        public Color GetParameterColor(object parameter)
        {
            if (parameter is LogTag logTag)
            {
                return GetTagColor(logTag);
            }

            return GetColorByParameterType(parameter);
        }

        private Color GetColorByParameterType(object parameter)
        {
            var parameterTypeName = parameter.GetType().Name;
            
            var parameterColor = _parametersColorsByType.Find(x =>
                x.Key.Contains(parameterTypeName, StringComparison.OrdinalIgnoreCase));

            return parameterColor.ContainsData() ? parameterColor.Color : _defaultParameterColor;
        }

        private Color GetTagColor(LogTag logTag)
        {
            if (TryGetKnownTagColor(logTag.Tag, out var color))
            {
                return color;
            }

            return GetUnknownTagColor();
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

        private Color GetUnknownTagColor()
        {
            if (_unknownTagColors is null || _unknownTagColors.Length == 0)
            {
                return new Color(Random.value, Random.value, Random.value);
            }

            var index = Random.Range(0, _unknownTagColors.Length);
            return _unknownTagColors[index];
        }
    }
}