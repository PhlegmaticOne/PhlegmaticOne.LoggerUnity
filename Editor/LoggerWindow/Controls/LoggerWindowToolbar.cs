using System;
using OpenMyGame.LoggerUnity.Editor.Base.Controls;
using OpenMyGame.LoggerUnity.Editor.Base.Extensions;
using OpenMyGame.LoggerUnity.Editor.Base.Styles;
using OpenMyGame.LoggerUnity.Editor.LoggerWindow.Components;
using OpenMyGame.LoggerUnity.Editor.LoggerWindow.Models;
using OpenMyGame.LoggerUnity.Editor.LoggerWindow.ViewConfig;
using OpenMyGame.LoggerUnity.Editor.TagsWindow.Models;
using OpenMyGame.LoggerUnity.Editor.TagsWindow.Views.Components;
using UnityEngine;
using UnityEngine.UIElements;

namespace OpenMyGame.LoggerUnity.Editor.LoggerWindow.Controls
{
    internal class LoggerWindowToolbar : HorizontalFlexBordered
    {
        private static readonly Color DebugColor = new(0.7686275f, 0.7686275f, 0.7686275f);
        private static readonly Color WarningColor = new(0.9058824f, 0.6980392f, 0.07058824f);
        private static readonly Color ErrorColor = new(1f, 0.3254902f, 0.2901961f);
        private static readonly Color FatalColor = new(1f, 0.3254902f, 0.2901961f);
        
        private readonly LoggerWindowViewConfig _viewConfig;

        private LoggerWindowSearchField _searchField;
        
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
            _searchField = new LoggerWindowSearchField(SearchFilterChanged);
            
            var logLevelsGroup = new HorizontalFlex(Justify.Center,
                    new LoggerWindowToggle(TagViewModel.Colorized("Fatal", FatalColor), 
                        (_, e) => OnLogLevelClick("Fatal", e)),
                    new LoggerWindowToggle(TagViewModel.Colorized("Error", ErrorColor), 
                        (_, e) => OnLogLevelClick("Error", e)),
                    new LoggerWindowToggle(TagViewModel.Colorized("Warning", WarningColor),
                        (_, e) => OnLogLevelClick("Warning", e)),
                    new LoggerWindowToggle(TagViewModel.Colorized("Debug", DebugColor),
                        (_, e) => OnLogLevelClick("Debug", e)))
                .WithStyle(x => x.height = LoggerWindowConstantStyles.ToolbarHeight)
                .WithStyle(x => x.marginTop = 1);
        
            return new HorizontalFlex(Justify.SpaceBetween, _searchField, logLevelsGroup);
        }

        private void OnLogLevelClick(string logLevel, bool isActive)
        {
            LogLevelClicked?.Invoke(new LogLevelClickEventArgs(logLevel, isActive));
        }

        public void SetSearchbarWidth(float windowWidth)
        {
            var newWidth = Mathf.Min(
                LoggerWindowConstantStyles.SearchBarWidth, 
                windowWidth - LoggerWindowConstantStyles.SearchBarMargin);
            
            _searchField.style.width = newWidth;
        }
    }
}