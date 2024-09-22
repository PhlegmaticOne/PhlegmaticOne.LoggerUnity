using UnityEngine;

namespace OpenMyGame.LoggerUnity.Runtime.Properties.Message.Tags
{
    public class TagColorProvider : ITagColorProvider
    {
        public Color GetTagColor(string tag)
        {
            return Color.blue;
        }
    }
}