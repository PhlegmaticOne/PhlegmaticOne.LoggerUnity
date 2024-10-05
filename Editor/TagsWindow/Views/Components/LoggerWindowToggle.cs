using System;
using OpenMyGame.LoggerUnity.Editor.TagsWindow.Models;
using OpenMyGame.LoggerUnity.Editor.TagsWindow.Views.Extensions;
using OpenMyGame.LoggerUnity.Editor.TagsWindow.Views.Styles;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace OpenMyGame.LoggerUnity.Editor.TagsWindow.Views.Components
{
    internal sealed class LoggerWindowToggle : ToolbarToggle
    {
        public TagViewModel ViewModel { get; }
        
        public LoggerWindowToggle(TagViewModel viewModel, Action<LoggerWindowToggle, bool> valueChanged)
        {
            ViewModel = viewModel;
            ChangeText(viewModel.Tag, viewModel.Color);
            style.minWidth = LoggerWindowConstantStyles.TooltipMinWidth;
            style.unityTextAlign = TextAnchor.MiddleCenter;
            SetValueWithoutNotify(false);
            this.AddBorder();
            this.RegisterValueChangedCallback(e => valueChanged(this, e.newValue));
        }

        public void ChangeText(string newText, in Color color)
        {
            style.color = color;
            text = newText;
        }
    }
}