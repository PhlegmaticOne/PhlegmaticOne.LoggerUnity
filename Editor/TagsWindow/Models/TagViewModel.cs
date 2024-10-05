using System;
using OpenMyGame.LoggerUnity.Tagging;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.Editor.TagsWindow.Models
{
    internal class TagViewModel : IEquatable<TagViewModel>
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

        public bool Equals(TagViewModel other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Tag == other.Tag;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((TagViewModel)obj);
        }

        public override int GetHashCode()
        {
            return Tag != null ? Tag.GetHashCode() : 0;
        }
    }
}