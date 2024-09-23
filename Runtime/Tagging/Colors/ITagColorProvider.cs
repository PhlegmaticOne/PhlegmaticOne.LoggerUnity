using UnityEngine;

namespace OpenMyGame.LoggerUnity.Tagging.Colors
{
    public interface ITagColorProvider
    {
        Color GetTagColor(string tag);
    }
}