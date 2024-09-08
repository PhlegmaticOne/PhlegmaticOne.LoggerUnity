using System;
using OpenMyGame.LoggerUnity.Editor.LoggerWindow.Components.Extensions;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace OpenMyGame.LoggerUnity.Editor.LoggerWindow.Components
{
    public sealed class LoggerWindowToggle : ToolbarToggle
    {
        public LoggerWindowToggle(string text, Color textColor, Action<bool> valueChanged)
        {
            this.text = text;
            style.minWidth = 40;
            style.color = textColor;
            style.unityTextAlign = TextAnchor.MiddleCenter;
            SetValueWithoutNotify(true);
            this.AddBorder();
            this.RegisterValueChangedCallback(e => valueChanged(e.newValue));
        }
    }
}