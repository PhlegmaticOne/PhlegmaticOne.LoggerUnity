using System.Collections.Concurrent;
using OpenMyGame.LoggerUnity.Extensions;
using OpenMyGame.LoggerUnity.Parameters.Processors.Colors.ViewConfig;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.Tagging.Providers
{
    internal class LogTagProvider : ILogTagProvider
    {
        private readonly ConcurrentDictionary<string, Color> _tagColorsMap;
        private readonly IParameterColorsViewConfig _colorsViewConfig;
        private readonly string _tagFormat;

        public LogTagProvider(string tagFormat, IParameterColorsViewConfig colorsViewConfig)
        {
            _tagFormat = tagFormat;
            _colorsViewConfig = colorsViewConfig;
            _tagColorsMap = new ConcurrentDictionary<string, Color>();
        }

        public LogTag CreateTag(string tag)
        {
            if (_tagColorsMap.TryGetValue(tag, out var tagColor))
            {
                return LogTag.Colorized(tag, tagColor);
            }

            var newTag = LogTag.TagOnly(tag);
            return newTag.WithColor(GetColorForTag(newTag));
        }

        public string FormatTag(string tag)
        {
            var tagFormat = _tagFormat.Replace(LogTag.TagKey, "0");
            
            if (_tagColorsMap.TryGetValue(tag, out var tagColor))
            {
                return string.Format(tagFormat, tag.Colorize(tagColor));
            }

            var newTagColor = GetColorForTag(LogTag.TagOnly(tag));
            return string.Format(tagFormat, tag.Colorize(newTagColor));
        }

        public string AddTagToFormat(string format)
        {
            return $"{_tagFormat} {format}";
        }

        private Color GetColorForTag(LogTag tag)
        {
            return _tagColorsMap.GetOrAdd(tag.Tag, _ => _colorsViewConfig.GetParameterColor(tag));
        }
    }
}