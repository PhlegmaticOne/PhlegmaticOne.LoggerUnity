using System;
using System.Collections.Concurrent;
using Openmygame.Logger.Configuration;

namespace Openmygame.Logger.Messages.Tagging
{
    public sealed class LogTagFormat : IEquatable<LogTagFormat>
    {
        private static readonly ConcurrentDictionary<string, LogTagFormat> Formats = new();
        
        private readonly ConcurrentDictionary<string, string> _formatsCache = new();

        public static LogTagFormat Default => GetFormat(LoggerConfigurationData.TagFormat);

        /// <example>[#{Tag}#]</example>
        public static LogTagFormat GetFormat(string format)
        {
            return Formats.GetOrAdd(format, f => new LogTagFormat(f));
        }
        
        public string Format { get; }
        public string Prefix { get; }
        public string Postfix { get; }
        
        internal LogTagFormat(string format)
        {
            var openIndex = format.IndexOf('{');
            var closeIndex = format.IndexOf('}') + 1;
            
            Prefix = format[..openIndex];
            Postfix = format[closeIndex..];
            Format = format[openIndex..closeIndex];
        }

        public string AddTagToFormat(string format)
        {
            return _formatsCache.GetOrAdd(format, f => $"{Format} {f}");
        }

        public override string ToString()
        {
            return Format;
        }

        public bool Equals(LogTagFormat other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Format == other.Format && Prefix == other.Prefix && Postfix == other.Postfix;
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is LogTagFormat other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Format, Prefix, Postfix);
        }
    }
}