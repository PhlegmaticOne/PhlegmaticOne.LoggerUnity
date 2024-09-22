using UnityEngine;

namespace OpenMyGame.LoggerUnity.Runtime.Properties.Message.Tags
{
    public interface ITagColorProvider
    {
        Color GetTagColor(string tag);
    }
}