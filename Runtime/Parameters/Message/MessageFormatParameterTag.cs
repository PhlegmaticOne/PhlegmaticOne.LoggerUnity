using System;
using System.Collections.Generic;
using OpenMyGame.LoggerUnity.Parameters.Message.Base;
using OpenMyGame.LoggerUnity.Tagging;
using OpenMyGame.LoggerUnity.Tagging.Colors;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.Parameters.Message
{
    internal class MessageFormatParameterTag : MessageFormatParameter<LogTag>
    {
        private readonly ITagColorProvider _tagColorProvider;
        private readonly Dictionary<string, Color> _tagColorsMap;
        
        public MessageFormatParameterTag(ITagColorProvider tagColorProvider)
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
            if (format.IsEmpty || format[0] != 'c')
            {
                return parameter.Tag;
            }

            if (_tagColorsMap.TryGetValue(parameter.Tag, out var tagColor))
            {
                return ColorizeTag(parameter, tagColor);
            }
            
            var newTagColor = _tagColorProvider.GetTagColor(parameter.Tag);
            _tagColorsMap[parameter.Tag] = newTagColor;
            return ColorizeTag(parameter, newTagColor);
        }

        private static string ColorizeTag(LogTag parameter, in Color color)
        {
            parameter.SetColor(color);
            return ColorizeTag(parameter.Tag, color);
        }
    }
}