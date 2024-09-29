using System;
using OpenMyGame.LoggerUnity.Editor.Base.Controls;
using OpenMyGame.LoggerUnity.Tagging;

namespace OpenMyGame.LoggerUnity.Editor.TagsWindow.Views.Factories
{
    public interface ITagControlFactory
    {
        LoggerWindowToggle CreateTagControl(LogTag tag, Action<LoggerWindowToggle, bool> onClick);
    }
}