using System;
using OpenMyGame.LoggerUnity.Editor.LoggerWindow.Components;
using OpenMyGame.LoggerUnity.Editor.LoggerWindow.Components.Base;
using OpenMyGame.LoggerUnity.Editor.LoggerWindow.Components.Extensions;
using OpenMyGame.LoggerUnity.Editor.LoggerWindow.Controls.EventData;
using OpenMyGame.LoggerUnity.Editor.LoggerWindow.Styles;
using OpenMyGame.LoggerUnity.Editor.ViewConfig;
using UnityEngine.UIElements;

namespace OpenMyGame.LoggerUnity.Editor.LoggerWindow.Controls
{
    public class LoggerWindowToolbar : HorizontalFlexBordered
    {
        private readonly LoggerWindowViewConfig _viewConfig;
        
        public event Action ClearClick;
        public event Action<string> SearchFilterChanged;
        public event Action<LogLevelClickEventArgs> LogLevelClicked;
        
        public LoggerWindowToolbar(LoggerWindowViewConfig viewConfig) : base(Justify.SpaceBetween)
        {
            _viewConfig = viewConfig;
            style.minHeight = LoggerWindowConstantStyles.ToolbarHeight;
            
            Add(ButtonsGroup());
            Add(ControlsGroup());
        }

        private VisualElement ButtonsGroup()
        {
            return new HorizontalFlex(Justify.SpaceBetween,
                 new LoggerWindowToolbarButton(LoggerWindowConstantStyles.ClearButtonText, ClearClick));
        }

        private VisualElement ControlsGroup()
        {
            var searchField = new LoggerWindowSearchField(SearchFilterChanged);
            var viewConfig = _viewConfig.ConfigData;
            
            var logLevelsGroup = new HorizontalFlex(Justify.Center,
                    new LoggerWindowToggle(viewConfig.FatalToggle.Text, viewConfig.FatalToggle.Color, 
                        e => OnLogLevelClick("Fatal", e)),
                    new LoggerWindowToggle(viewConfig.ErrorToggle.Text, viewConfig.ErrorToggle.Color, 
                        e => OnLogLevelClick("Error", e)),
                    new LoggerWindowToggle(viewConfig.WarningToggle.Text, viewConfig.WarningToggle.Color,
                        e => OnLogLevelClick("Warning", e)),
                    new LoggerWindowToggle(viewConfig.DebugToggle.Text, viewConfig.DebugToggle.Color,
                        e => OnLogLevelClick("Debug", e)))
                .WithStyle(x => x.height = LoggerWindowConstantStyles.ToolbarHeight)
                .WithStyle(x => x.marginTop = 1);

            return new HorizontalFlex(Justify.SpaceBetween, searchField, logLevelsGroup);
        }

        private void OnLogLevelClick(string logLevel, bool isActive)
        {
            LogLevelClicked?.Invoke(new LogLevelClickEventArgs(logLevel, isActive));
        }
    }
}