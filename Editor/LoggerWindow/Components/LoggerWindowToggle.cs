using System;
using OpenMyGame.LoggerUnity.Editor.LoggerWindow.Components.Extensions;
using OpenMyGame.LoggerUnity.Editor.LoggerWindow.Styles;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace OpenMyGame.LoggerUnity.Editor.LoggerWindow.Components
{
    public sealed class LoggerWindowToggle : ToolbarToggle
    {
        public string Text { get; private set; }
        
        public LoggerWindowToggle(string text, Color textColor, Action<LoggerWindowToggle, bool> valueChanged)
        {
            ChangeText(text);
            style.minWidth = LoggerWindowConstantStyles.TooltipMinWidth;
            style.color = textColor;
            style.unityTextAlign = TextAnchor.MiddleCenter;
            SetValueWithoutNotify(false);
            this.AddBorder();
            this.RegisterValueChangedCallback(e => valueChanged(this, e.newValue));
        }

        public void ChangeText(string newText)
        {
            Text = newText;
            text = newText;
        }
    }
}