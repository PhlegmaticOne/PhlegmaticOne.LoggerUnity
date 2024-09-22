using System;
using OpenMyGame.LoggerUnity.Editor.TagsWindow.Views.Extensions;
using OpenMyGame.LoggerUnity.Editor.ViewConfig;
using OpenMyGame.LoggerUnity.Editor.ViewConfig.Models;
using UnityEngine.UIElements;

namespace OpenMyGame.LoggerUnity.Editor.LoggerWindow.Controls
{
    public class LoggerWindowLogsScroll : ScrollView
    {
        private readonly LoggerWindowViewConfig _viewConfig;

        private LoggerWindowLog _selectedLog;
        private int _logsCount;

        public event Action<LoggerWindowLog> LogClick;
        
        public LoggerWindowLogsScroll(LoggerWindowViewConfig viewConfig) : base(ScrollViewMode.Vertical)
        {
            _viewConfig = viewConfig;
            style.height = 300;
            style.marginTop = -1;
            this.AddBorder();
        }

        public void AddLog(string logText)
        {
            Add(new LoggerWindowLog(logText, GetLogColor(), _viewConfig, HandleLogClick));
            _logsCount++;
        }

        private void HandleLogClick(LoggerWindowLog selectedLog)
        {
            _selectedLog?.Deselect();
            _selectedLog = selectedLog;
            LogClick?.Invoke(selectedLog);
        }
        
        private LoggerWindowColorConfigData GetLogColor()
        {
            var viewConfig = _viewConfig.ConfigData;
            var colorIndex = _logsCount % viewConfig.DebugColors.Length;
            return _viewConfig.ConfigData.DebugColors[colorIndex];
        }
    }
}