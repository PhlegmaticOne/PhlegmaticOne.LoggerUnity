using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace OpenMyGame.LoggerUnity.Tagging.Colors.ViewConfig
{
    public class TagColorsViewConfig : ScriptableObject
    {
        [SerializeField] private List<TagColorConfigData> _knownTagsColors;
        [SerializeField] private Color[] _unknownTagColors;

        internal static TagColorsViewConfig Load()
        {
            return Resources.Load<TagColorsViewConfig>("TagColorsViewConfig");
        }

        public bool TryGetKnownTagColor(string tag, out Color color)
        {
            var tagData = _knownTagsColors.Find(x => x.Tag.Equals(tag, StringComparison.OrdinalIgnoreCase));

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