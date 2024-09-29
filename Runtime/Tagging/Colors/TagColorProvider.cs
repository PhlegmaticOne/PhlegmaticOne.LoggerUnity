using OpenMyGame.LoggerUnity.Tagging.Colors.ViewConfig;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.Tagging.Colors
{
    internal class TagColorProvider : ITagColorProvider
    {
        private readonly TagColorsViewConfig _colorsViewConfig;
        
        public TagColorProvider(TagColorsViewConfig colorsViewConfig)
        {
            _colorsViewConfig = colorsViewConfig;
        }
        
        public Color GetTagColor(string tag)
        {
            if (_colorsViewConfig.TryGetKnownTagColor(tag, out var color))
            {
                return color;
            }

            return _colorsViewConfig.GetUnknownTagColor();
        }
    }
}