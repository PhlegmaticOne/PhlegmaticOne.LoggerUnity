using System;
using OpenMyGame.LoggerUnity.Editor.LoggerWindow.Components;

namespace OpenMyGame.LoggerUnity.Editor.TagsWindow.Factories
{
    public interface ITagControlFactory
    {
        LoggerWindowToggle CreateTagControl(string tag, Action<LoggerWindowToggle, bool> onClick);
    }
}