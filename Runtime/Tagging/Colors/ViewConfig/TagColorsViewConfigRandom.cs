using UnityEngine;

namespace OpenMyGame.LoggerUnity.Tagging.Colors.ViewConfig
{
    public class TagColorsViewConfigRandom : ITagColorsViewConfig
    {
        public bool TryGetKnownTagColor(string tag, out Color color)
        {
            color = CreateRandomColor();
            return true;
        }

        public Color GetUnknownTagColor()
        {
            return CreateRandomColor();
        }

        private static Color CreateRandomColor()
        {
            return new Color(Random.value, Random.value, Random.value);
        }
    }
}