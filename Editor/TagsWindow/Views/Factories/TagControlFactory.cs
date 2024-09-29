using System;
using OpenMyGame.LoggerUnity.Editor.Base.Controls;
using OpenMyGame.LoggerUnity.Editor.Base.Extensions;
using OpenMyGame.LoggerUnity.Editor.Base.Styles;
using OpenMyGame.LoggerUnity.Tagging;

namespace OpenMyGame.LoggerUnity.Editor.TagsWindow.Views.Factories
{
    public class TagControlFactory : ITagControlFactory
    {
        public LoggerWindowToggle CreateTagControl(LogTag tag, Action<LoggerWindowToggle, bool> onClick)
        {
            return new LoggerWindowToggle(tag.Tag, tag.Color, onClick)
                .WithStyle(x => x.AddMargin(1))
                .WithStyle(x => x.height = LoggerWindowConstantStyles.ToolbarHeight);
        }
    }
}