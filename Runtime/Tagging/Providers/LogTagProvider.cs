using System.Collections.Concurrent;
using OpenMyGame.LoggerUnity.Extensions;
using OpenMyGame.LoggerUnity.Parsing.Models;
using OpenMyGame.LoggerUnity.Tagging.Colors;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.Tagging.Providers
{
    internal class LogTagProvider : ILogTagProvider
    {
        private readonly ITagColorProvider _tagColorProvider;
        private readonly ConcurrentDictionary<string, Color> _tagColorsMap;
        private readonly string _tagFormat;
        private readonly bool _isColorize;

        public LogTagProvider(string tagFormat, ITagColorProvider tagColorProvider)
        {
            _tagFormat = tagFormat;
            _tagColorProvider = tagColorProvider;
            _isColorize = MessagePart.Parameter(tagFormat).HasFormat("c");
            _tagColorsMap = new ConcurrentDictionary<string, Color>();
        }

        public LogTag CreateTag(string tag)
        {
            if (!_isColorize)
            {
                return LogTag.Transparent(tag);
            }
            
            if (_tagColorsMap.TryGetValue(tag, out var tagColor))
            {
                return LogTag.Colorized(tag, tagColor);
            }

            var newTagColor = _tagColorsMap.GetOrAdd(tag, t => _tagColorProvider.GetTagColor(t));
            return LogTag.Colorized(tag, newTagColor);
        }

        public string FormatTag(string tag)
        {
            var tagFormat = _tagFormat.Replace(LogTag.TagKey, "0");
            
            if (!_isColorize)
            {
                return string.Format(tagFormat, tag);
            }
            
            if (_tagColorsMap.TryGetValue(tag, out var tagColor))
            {
                return string.Format(tagFormat, tag.Colorize(tagColor));
            }

            var newTagColor = _tagColorsMap.GetOrAdd(tag, t => _tagColorProvider.GetTagColor(t));
            return string.Format(tagFormat, tag.Colorize(newTagColor));
        }

        public string AddTagToFormat(string format)
        {
            return $"{_tagFormat} {format}";
        }
    }
}