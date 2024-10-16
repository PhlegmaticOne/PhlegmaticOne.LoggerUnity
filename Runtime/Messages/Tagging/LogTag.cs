﻿using System;
using Newtonsoft.Json;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.Messages.Tagging
{
    [Serializable]
    public struct LogTag : IEquatable<LogTag>
    {
        public const string TagKey = "Tag";

        public static LogTag Empty => new(string.Empty, false, Color.white);
        
        public static LogTag Colorized(string tag, Color color)
        {
            return new LogTag(tag, true, color);
        }

        public static LogTag TagOnly(string tag)
        {
            return new LogTag(tag, false, Color.white);
        }

        private LogTag(string value, bool hasColor, Color color)
        {
            Value = value;
            HasColor = hasColor;
            Color = color;
        }

        [JsonProperty("Value")] public string Value { get; }
        [JsonIgnore] public Color Color { get; private set; }
        [JsonIgnore] public bool HasColor { get; private set; }

        public void SetColor(Color color)
        {
            Color = color;
            HasColor = true;
        }

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