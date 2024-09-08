using System;
using OpenMyGame.LoggerUnity.Editor.LoggerWindow.Components;
using OpenMyGame.LoggerUnity.Editor.LoggerWindow.Components.Base;
using OpenMyGame.LoggerUnity.Editor.LoggerWindow.Components.Extensions;
using OpenMyGame.LoggerUnity.Editor.LoggerWindow.Controls.EventData;
using UnityEngine;
using UnityEngine.UIElements;

namespace OpenMyGame.LoggerUnity.Editor.LoggerWindow.Controls
{
    public class LoggerWindowToolbar : HorizontalFlexBordered
    {
        public event Action ClearClick;
        public event Action<string> SearchFilterChanged;
        public event Action<LogLevelClickEventArgs> LogLevelClicked;
        
        public LoggerWindowToolbar() : base(Justify.SpaceBetween)
        {
            OverrideStyle();
            
            Add(ButtonsGroup());
            Add(ControlsGroup());
        }

        private VisualElement ButtonsGroup()
        {
            return new HorizontalFlex(Justify.SpaceBetween,
                 new LoggerWindowToolbarButton("Clear", ClearClick));
        }

        private VisualElement ControlsGroup()
        {
            var searchField = new LoggerWindowSearchField(SearchFilterChanged);

            var logLevelsGroup = new HorizontalFlex(Justify.Center,
                    new LoggerWindowToggle("E", Color.red, e => OnLogLevelClick("Error", e)),
                    new LoggerWindowToggle("W", Color.yellow, e => OnLogLevelClick("Warning", e)),
                    new LoggerWindowToggle("L", Color.grey, e => OnLogLevelClick("Log", e)))
                .WithStyle(x => x.height = 20)
                .WithStyle(x => x.marginTop = 1);

            return new HorizontalFlex(Justify.SpaceBetween, searchField, logLevelsGroup);
        }

        private void OnLogLevelClick(string logLevel, bool isActive)
        {
            LogLevelClicked?.Invoke(new LogLevelClickEventArgs(logLevel, isActive));
        }

        private void OverrideStyle()
        {
            style.minHeight = 20;
        }
    }
}