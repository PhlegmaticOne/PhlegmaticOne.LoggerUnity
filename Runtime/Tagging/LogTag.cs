using System;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.Tagging
{
    public class LogTag : IEquatable<LogTag>
    {
        public LogTag(string tag)
        {
            Tag = tag;
            Color = Color.white;
        }

        public string Tag { get; }
        public Color Color { get; private set; }

        public void SetColor(in Color color)
        {
            Color = color;
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