using System;
using OpenMyGame.LoggerUnity.Editor.LoggerWindow.Components;
using OpenMyGame.LoggerUnity.Editor.LoggerWindow.Components.Extensions;
using OpenMyGame.LoggerUnity.Editor.LoggerWindow.Styles;
using OpenMyGame.LoggerUnity.Runtime.Tagging;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.Editor.TagsWindow.Factories
{
    public class TagControlFactory : ITagControlFactory
    {
        public LoggerWindowToggle CreateTagControl(LogTag tag, Action<LoggerWindowToggle, bool> onClick)
        {
            return new LoggerWindowToggle(tag.TagValue, tag.Color, onClick)
                .WithStyle(x => x.AddMargin(1))
                .WithStyle(x => x.height = LoggerWindowConstantStyles.ToolbarHeight);
        }
    }
}