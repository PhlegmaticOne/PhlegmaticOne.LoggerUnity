using System;
using Newtonsoft.Json;
using OpenMyGame.LoggerUnity.Base;

namespace OpenMyGame.LoggerUnity.Messages.Tagging
{
    [Serializable]
    public struct LogTag : IEquatable<LogTag>
    {
        public static LogTagFormat Format { get; } = new(LoggerStaticData.TagFormat);
        
        public static LogTag Empty => new(string.Empty);
        
        public LogTag(string value)
        {
            Value = value;
        }

        [JsonProperty("Value")] public string Value { get; }

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