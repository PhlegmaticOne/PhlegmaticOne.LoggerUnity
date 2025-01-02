using System;

namespace Openmygame.Logger.Messages.Tagging
{
    [Serializable]
    public struct LogTag : IEquatable<LogTag>
    {
        public static LogTag Empty => new(string.Empty, LogTagFormat.Default);
        
        public LogTag(string value) : this(value, LogTagFormat.Default) { }
        
        public LogTag(string value, LogTagFormat format)
        {
            Value = value;
            Format = format;
        }

        public string Value { get; }
        public LogTagFormat Format { get; }

        public bool HasValue()
        {
            return !string.IsNullOrEmpty(Value);
        }
        
        public bool Equals(LogTag other)
        {
            return Value == other.Value;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj.GetType() == GetType() && Equals((LogTag)obj);
        }

        public override int GetHashCode()
        {
            return Value != null ? Value.GetHashCode() : 0;
        }

        public override string ToString()
        {
            return Value;
        }
    }
}