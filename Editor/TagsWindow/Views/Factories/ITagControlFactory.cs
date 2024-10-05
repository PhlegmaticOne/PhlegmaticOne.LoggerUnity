using System;
using OpenMyGame.LoggerUnity.Editor.TagsWindow.Models;
using OpenMyGame.LoggerUnity.Editor.TagsWindow.Views.Components;

namespace OpenMyGame.LoggerUnity.Editor.TagsWindow.Views.Factories
{
    internal interface ITagControlFactory
    {
        LoggerWindowToggle CreateTagControl(TagViewModel tag, Action<LoggerWindowToggle, bool> onClick);
    }
}