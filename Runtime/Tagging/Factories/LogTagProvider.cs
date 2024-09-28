using System.Collections.Generic;
using OpenMyGame.LoggerUnity.Parsing.Models;
using OpenMyGame.LoggerUnity.Tagging.Colors;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.Tagging.Factories
{
    internal class LogTagProvider : ILogTagProvider
    {
        private readonly ITagColorProvider _tagColorProvider;
        private readonly Dictionary<string, Color> _tagColorsMap;
        private readonly string _tagFormat;
        private readonly bool _isColorize;

        public LogTagProvider(string tagFormat, ITagColorProvider tagColorProvider)
        {
            _tagFormat = tagFormat;
            _tagColorProvider = tagColorProvider;
            _isColorize = MessagePart.Parameter(tagFormat).HasFormat("c");
            _tagColorsMap = new Dictionary<string, Color>();
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
            
            var newTagColor = _tagColorProvider.GetTagColor(tag);
            _tagColorsMap[tag] = newTagColor;
            return LogTag.Colorized(tag, newTagColor);
        }

        public string AddTagToFormat(string format)
        {
            return $"{_tagFormat} {format}";
        }
    }
}