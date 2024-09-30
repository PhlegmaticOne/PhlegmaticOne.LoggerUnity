using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace OpenMyGame.LoggerUnity.Tagging.Colors.ViewConfig
{
    public class TagColorsViewConfig : ScriptableObject, ITagColorsViewConfig
    {
        [SerializeField] private List<TagColorConfigData> _knownTagColors;
        [SerializeField] private Color[] _unknownTagColors;

        public static ITagColorsViewConfig Load()
        {
            var config = Resources.Load<TagColorsViewConfig>("LoggerUnity/TagColorsViewConfig");
            return config == null ? new TagColorsViewConfigRandom() : config;
        }

        public bool TryGetKnownTagColor(string tag, out Color color)
        {
            var tagData = _knownTagColors.Find(x => x.Tag.Equals(tag, StringComparison.OrdinalIgnoreCase));

            if (string.IsNullOrEmpty(tagData.Tag))
            {
                color = Color.clear;
                return false;
            }

            color = tagData.Color;
            return true;
        }

        public Color GetUnknownTagColor()
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