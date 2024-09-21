using System;
using OpenMyGame.LoggerUnity.Editor.LoggerWindow.Components;
using OpenMyGame.LoggerUnity.Editor.LoggerWindow.Components.Extensions;
using OpenMyGame.LoggerUnity.Editor.LoggerWindow.Styles;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.Editor.TagsWindow.Factories
{
    public class TagControlFactory : ITagControlFactory
    {
        public LoggerWindowToggle CreateTagControl(string tag, Action<LoggerWindowToggle, bool> onClick)
        {
            return new LoggerWindowToggle(tag, Color.white, onClick)
                .WithStyle(x => x.AddMargin(1))
                .WithStyle(x => x.height = LoggerWindowConstantStyles.ToolbarHeight);
        }
    }
}