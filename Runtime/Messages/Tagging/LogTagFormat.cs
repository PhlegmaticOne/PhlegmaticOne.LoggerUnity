using System.Collections.Concurrent;

namespace OpenMyGame.LoggerUnity.Messages.Tagging
{
    public class LogTagFormat
    {
        private static readonly ConcurrentDictionary<string, string> FormatsCache = new();
        
        public string Format { get; private set; }
        public string Prefix { get; private set; }
        public string Postfix { get; private set; }
        
        public LogTagFormat(string format)
        {
            UpdateFormat(format);
        }

        public void UpdateFormat(string format)
        {
            var openIndex = format.IndexOf('{');
            var closeIndex = format.IndexOf('}') + 1;
            
            Prefix = format[..openIndex];
            Postfix = format[closeIndex..];
            Format = format[openIndex..closeIndex];
        }
        
        public string AddTagToFormat(string format)
        {
            return FormatsCache.GetOrAdd(format, f => $"{Format} {f}");
        }
    }
}