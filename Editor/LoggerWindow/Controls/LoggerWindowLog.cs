using System;
using OpenMyGame.LoggerUnity.Editor.Base.Styles;
using OpenMyGame.LoggerUnity.Editor.LoggerWindow.ViewConfig;
using OpenMyGame.LoggerUnity.Editor.LoggerWindow.ViewConfig.Models;
using UnityEngine;
using UnityEngine.UIElements;

namespace OpenMyGame.LoggerUnity.Editor.LoggerWindow.Controls
{
    public sealed class LoggerWindowLog : TextElement
    {
        private readonly LoggerWindowColorConfigData _colorData;
        private readonly LoggerWindowViewConfig _viewConfig;
        private readonly Action<LoggerWindowLog> _onClick;
        
        private bool _isSelected;
        
        public LoggerWindowLog(
            string logText, 
            LoggerWindowColorConfigData colorData, 
            LoggerWindowViewConfig viewConfig,
            Action<LoggerWindowLog> onClick)
        {
            _colorData = colorData;
            _viewConfig = viewConfig;
            _onClick = onClick;
            
            text = logText;
            style.minHeight = LoggerWindowConstantStyles.LogEntryMinHeight;
            style.paddingLeft = 20;
            style.unityTextAlign = TextAnchor.MiddleLeft;
            
            UpdateSelected(false);
            this.AddManipulator(new Clickable(HandleClick));
        }

        public void Deselect()
        {
            UpdateSelected(false);
        }

        private void HandleClick(EventBase eventBase)
        {
            if (_isSelected)
            {
                return;
            }
            
            _onClick.Invoke(this);
            UpdateSelected(true);
        }

        private void UpdateSelected(bool isSelected)
        {
            _isSelected = isSelected;

            var colorData = _isSelected ? _viewConfig.SelectedLogColor : _colorData;
            style.backgroundColor = colorData.BackgroundColor;
            style.color = colorData.TextColor;
        }
    }
}