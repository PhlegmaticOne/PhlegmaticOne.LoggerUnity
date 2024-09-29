using System;
using OpenMyGame.LoggerUnity.Editor.Base.Extensions;
using OpenMyGame.LoggerUnity.Editor.LoggerWindow.ViewConfig;
using OpenMyGame.LoggerUnity.Editor.LoggerWindow.ViewConfig.Models;
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
            var colorIndex = _logsCount % _viewConfig.DebugColors.Length;
            return _viewConfig.DebugColors[colorIndex];
        }
    }
}