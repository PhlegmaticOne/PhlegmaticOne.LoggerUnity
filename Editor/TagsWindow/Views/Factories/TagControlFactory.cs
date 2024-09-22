using System;
using OpenMyGame.LoggerUnity.Editor.TagsWindow.Views.Components;
using OpenMyGame.LoggerUnity.Editor.TagsWindow.Views.Extensions;
using OpenMyGame.LoggerUnity.Editor.TagsWindow.Views.Styles;
using OpenMyGame.LoggerUnity.Runtime.Tagging;

namespace OpenMyGame.LoggerUnity.Editor.TagsWindow.Views.Factories
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