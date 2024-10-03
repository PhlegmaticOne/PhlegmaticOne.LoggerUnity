using System;
using OpenMyGame.LoggerUnity.Editor.Base.Extensions;
using OpenMyGame.LoggerUnity.Editor.Base.Styles;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace OpenMyGame.LoggerUnity.Editor.Base.Controls
{
    internal sealed class LoggerWindowToggle : ToolbarToggle
    {
        public string Text { get; private set; }
        
        public LoggerWindowToggle(string text, Color textColor, Action<LoggerWindowToggle, bool> valueChanged)
        {
            ChangeText(text, textColor);
            style.minWidth = LoggerWindowConstantStyles.TooltipMinWidth;
            style.unityTextAlign = TextAnchor.MiddleCenter;
            SetValueWithoutNotify(false);
            this.AddBorder();
            this.RegisterValueChangedCallback(e => valueChanged(this, e.newValue));
        }

        public void ChangeText(string newText, in Color color)
        {
            style.color = color;
            Text = newText;
            text = newText;
        }
    }
}