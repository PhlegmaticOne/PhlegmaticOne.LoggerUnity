using UnityEngine;

namespace OpenMyGame.LoggerUnity.Tagging.Colors.ViewConfig
{
    public interface ITagColorsViewConfig
    {
        bool TryGetKnownTagColor(string tag, out Color color);
        Color GetUnknownTagColor();
    }
}