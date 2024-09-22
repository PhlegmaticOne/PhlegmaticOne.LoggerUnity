using System;
using OpenMyGame.LoggerUnity.Editor.TagsWindow.Views.Components;
using OpenMyGame.LoggerUnity.Runtime.Tagging;

namespace OpenMyGame.LoggerUnity.Editor.TagsWindow.Views.Factories
{
    public interface ITagControlFactory
    {
        LoggerWindowToggle CreateTagControl(LogTag tag, Action<LoggerWindowToggle, bool> onClick);
    }
}