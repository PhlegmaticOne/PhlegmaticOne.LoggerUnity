using UnityEngine;

namespace OpenMyGame.LoggerUnity.Runtime.Tagging.Colors
{
    public interface ITagColorProvider
    {
        Color GetTagColor(string tag);
    }
}