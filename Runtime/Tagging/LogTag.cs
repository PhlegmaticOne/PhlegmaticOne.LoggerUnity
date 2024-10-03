using System;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.Tagging
{
    public class LogTag : IEquatable<LogTag>
    {
        public const string TagKey = "Tag";

        public static LogTag Colorized(string tag, Color color)
        {
            return new LogTag(tag, true, color);
        }

        public static LogTag TagOnly(string tag)
        {
            return new LogTag(tag, false, Color.white);
        }

        private LogTag(string tag, bool hasColor, Color color)
        {
            Tag = tag;
            HasColor = hasColor;
            Color = color;
        }

        public string Tag { get; }
        public Color Color { get; private set; }
        public bool HasColor { get; private set; }

        public LogTag WithColor(Color color)
        {
            Color = color;
            HasColor = true;
            return this;
        }
        
        public bool Equals(LogTag other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Tag == other.Tag;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((LogTag)obj);
        }

        public override int GetHashCode()
        {
            return Tag != null ? Tag.GetHashCode() : 0;
        }
    }
}