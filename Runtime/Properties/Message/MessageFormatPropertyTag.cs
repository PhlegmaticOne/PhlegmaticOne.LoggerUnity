﻿using System;
using System.Collections.Generic;
using OpenMyGame.LoggerUnity.Runtime.Properties.Message.Base;
using OpenMyGame.LoggerUnity.Runtime.Properties.Message.Tags;
using OpenMyGame.LoggerUnity.Runtime.Tagging;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.Runtime.Properties.Message
{
    internal class MessageFormatPropertyTag : MessageFormatProperty<LogTag>
    {
        private readonly ITagColorProvider _tagColorProvider;
        private readonly Dictionary<string, Color> _tagColorsMap;
        
        public MessageFormatPropertyTag(ITagColorProvider tagColorProvider)
        {
            _tagColorProvider = tagColorProvider;
            _tagColorsMap = new Dictionary<string, Color>();
        }

        public static string ColorizeTag(string tag, in Color color)
        {
            var colorString = ColorUtility.ToHtmlStringRGB(color);
            return $"<color=#{colorString}>{tag}</color>";
        }

        protected override ReadOnlySpan<char> Render(LogTag parameter, in ReadOnlySpan<char> format)
        {
            if (format.IsEmpty)
            {
                return parameter.TagValue;
            }

            if (_tagColorsMap.TryGetValue(parameter.TagValue, out var tagColor))
            {
                return ColorizeTag(parameter, tagColor);
            }
            
            var newTagColor = _tagColorProvider.GetTagColor(parameter.TagValue);
            _tagColorsMap[parameter.TagValue] = newTagColor;
            return ColorizeTag(parameter, newTagColor);
        }

        private static string ColorizeTag(LogTag parameter, in Color color)
        {
            parameter.SetColor(color);
            return ColorizeTag(parameter.TagValue, color);
        }
    }
}