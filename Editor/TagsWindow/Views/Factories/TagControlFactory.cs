using System;
using OpenMyGame.LoggerUnity.Editor.TagsWindow.Models;
using OpenMyGame.LoggerUnity.Editor.TagsWindow.Views.Components;
using OpenMyGame.LoggerUnity.Editor.TagsWindow.Views.Extensions;
using OpenMyGame.LoggerUnity.Editor.TagsWindow.Views.Styles;

namespace OpenMyGame.LoggerUnity.Editor.TagsWindow.Views.Factories
{
    internal class TagControlFactory : ITagControlFactory
    {
        public LoggerWindowToggle CreateTagControl(TagViewModel tag, Action<LoggerWindowToggle, bool> onClick)
        {
            return new LoggerWindowToggle(tag, onClick)
                .WithStyle(x => x.AddMargin(1))
                .WithStyle(x => x.height = LoggerWindowConstantStyles.ToolbarHeight);
        }
    }
}