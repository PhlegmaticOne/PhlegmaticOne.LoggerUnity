using System.Collections.Concurrent;
using OpenMyGame.LoggerUnity.Configuration;

namespace OpenMyGame.LoggerUnity.Messages.Tagging
{
    public class LogTagFormat
    {
        private readonly ConcurrentDictionary<string, string> _formatsCache = new();

        public static readonly LogTagFormat Default = new(LoggerConfigurationData.TagFormat);
        
        public string Format { get; private set; }
        public string Prefix { get; private set; }
        public string Postfix { get; private set; }

        public LogTagFormat(string format)
        {
            UpdateFormat(format);
        }

        public string AddTagToFormat(string format)
        {
            return _formatsCache.GetOrAdd(format, f => $"{Format} {f}");
        }

        public override string ToString()
        {
            return Format;
        }

        private void UpdateFormat(string format)
        {
            var openIndex = format.IndexOf('{');
            var closeIndex = format.IndexOf('}') + 1;
            
            Prefix = format[..openIndex];
            Postfix = format[closeIndex..];
            Format = format[openIndex..closeIndex];
        }
    }
}