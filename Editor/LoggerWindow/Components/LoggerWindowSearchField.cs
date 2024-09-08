using System;
using UnityEngine.UIElements;

namespace OpenMyGame.LoggerUnity.Editor.LoggerWindow.Components
{
    public class LoggerWindowSearchField : TextField
    {
        public LoggerWindowSearchField(Action<string> valueChanged)
        {
            style.width = 300;
            style.marginRight = 10;
            style.height = 20;
            tooltip = "Search filter";
            this.RegisterValueChangedCallback(e => valueChanged(e.newValue));
        }
    }
}