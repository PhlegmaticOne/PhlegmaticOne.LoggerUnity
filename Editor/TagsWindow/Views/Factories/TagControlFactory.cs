using System;
using OpenMyGame.LoggerUnity.Editor.Base.Extensions;
using OpenMyGame.LoggerUnity.Editor.Base.Styles;
using OpenMyGame.LoggerUnity.Editor.TagsWindow.Models;
using OpenMyGame.LoggerUnity.Editor.TagsWindow.Views.Components;

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