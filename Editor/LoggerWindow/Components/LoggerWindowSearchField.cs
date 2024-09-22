﻿using System;
using OpenMyGame.LoggerUnity.Editor.TagsWindow.Views.Styles;
using UnityEngine.UIElements;

namespace OpenMyGame.LoggerUnity.Editor.LoggerWindow.Components
{
    public class LoggerWindowSearchField : TextField
    {
        public LoggerWindowSearchField(Action<string> valueChanged)
        {
            style.width = LoggerWindowConstantStyles.SearchBarWidth;
            style.marginRight = 10;
            style.height = LoggerWindowConstantStyles.ToolbarHeight;
            tooltip = LoggerWindowConstantStyles.SearchBarTooltip;
            this.RegisterValueChangedCallback(e => valueChanged(e.newValue));
        }
    }
}