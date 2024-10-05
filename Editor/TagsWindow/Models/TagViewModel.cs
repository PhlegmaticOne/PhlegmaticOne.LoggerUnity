using OpenMyGame.LoggerUnity.Tagging;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.Editor.TagsWindow.Models
{
    internal class TagViewModel
    {
        public string Tag { get; }
        public bool HasColor { get; }
        public Color Color { get; }

        public static TagViewModel FromTag(LogTag logTag)
        {
            return new TagViewModel(logTag.Tag, logTag.HasColor, logTag.Color);
        }

        public TagViewModel(string tag, bool hasColor, Color color)
        {
            Tag = tag;
            HasColor = hasColor;
            Color = color;
        }
    }
}