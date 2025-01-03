using System;
using JetBrains.Annotations;

namespace Openmygame.Logger.Messages.Tagging
{
    public readonly struct Tag : IEquatable<Tag>
    {
        public static Tag Create(string value, string format, bool isSubsystem)
        {
            return new Tag(value, LogTagFormat.GetFormat(format), isSubsystem);
        }

        public static Tag Empty => new(null, null, false);
        
        public Tag(string value, LogTagFormat format, bool isSubsystem)
        {
            Value = value;
            Format = format;
            IsSubsystem = isSubsystem;
        }

        public string Value { get; }
        public LogTagFormat Format { get; }
        public bool IsSubsystem { get; }

        [UsedImplicitly]
        public bool HasValue()
        {
            return !string.IsNullOrEmpty(Value);
        }

        public string AddToFormat(string format)
        {
            return Format.AddTagToFormat(format);
        }

        public override string ToString()
        {
            return Value;
        }

        public bool Equals(Tag other)
        {
            return Value == other.Value && Equals(Format, other.Format) && IsSubsystem == other.IsSubsystem;
        }

        public override bool Equals(object obj)
        {
            return obj is Tag other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value, Format, IsSubsystem);
        }
    }
}