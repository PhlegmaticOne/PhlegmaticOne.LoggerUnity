using System;
using OpenMyGame.LoggerUnity.Editor.LoggerWindow.Components.Extensions;
using UnityEngine;
using UnityEngine.UIElements;

namespace OpenMyGame.LoggerUnity.Editor.LoggerWindow.Controls
{
    public class LoggerWindowLogsScroll : ScrollView
    {
        private static readonly Color ErrorColor = new(0.6509804f, 0.1960784f, 0.1960784f);
        private static readonly Color WarningColor = new(0.5882353f, 0.3764706f, 0.05490196f);
        private static readonly Color LogColorLight = new(0.2470588f, 0.2470588f, 0.2470588f);
        private static readonly Color LogColorDark = new(0.2196079f, 0.2196079f, 0.2196079f);
        
        private int _logsCount;
        private LoggerWindowLog _selectedLog;

        public event Action<LoggerWindowLog> LogClick;
        
        public LoggerWindowLogsScroll() : base(ScrollViewMode.Vertical)
        {
            style.height = 300;
            style.marginTop = -1;
            this.AddBorder();
        }

        public void AddLog(string logText)
        {
            Add(new LoggerWindowLog(logText, GetLogColor(), HandleLogClick));
            _logsCount++;
        }

        private void HandleLogClick(LoggerWindowLog selectedLog)
        {
            _selectedLog?.Deselect();
            _selectedLog = selectedLog;
            LogClick?.Invoke(selectedLog);
        }
        
        private Color GetLogColor()
        {
            return _logsCount % 2 == 0 ? LogColorLight : LogColorDark;
        }
    }
}