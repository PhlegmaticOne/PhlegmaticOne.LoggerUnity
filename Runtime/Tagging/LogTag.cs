using System;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.Runtime.Tagging
{
    public class LogTag : IEquatable<LogTag>
    {
        public LogTag(string tagValue)
        {
            TagValue = tagValue;
            Color = Color.white;
        }

        public string TagValue { get; }
        public Color Color { get; private set; }

        public void SetColor(in Color color)
        {
            Color = color;
        }

        public bool Equals(LogTag other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return TagValue == other.TagValue;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((LogTag)obj);
        }

        public override int GetHashCode()
        {
            return (TagValue != null ? TagValue.GetHashCode() : 0);
        }
    }
}