using System;
using OpenMyGame.LoggerUnity.Editor.Base.Styles;
using UnityEngine.UIElements;

namespace OpenMyGame.LoggerUnity.Editor.LoggerWindow.Components
{
    internal class LoggerWindowSearchField : TextField
    {
        public LoggerWindowSearchField(Action<string> valueChanged)
        {
            style.width = LoggerWindowConstantStyles.SearchBarWidth;
            style.marginRight = LoggerWindowConstantStyles.SearchBarMargin;
            style.height = LoggerWindowConstantStyles.ToolbarHeight;
            tooltip = LoggerWindowConstantStyles.SearchBarTooltip;
            this.RegisterValueChangedCallback(e => valueChanged(e.newValue));
        }
    }
}