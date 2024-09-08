using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace OpenMyGame.LoggerUnity.Editor.LoggerWindow.Controls
{
    public sealed class LoggerWindowLog : TextElement
    {
        private static readonly Color SelectedColor = new(0.172549f, 0.3647059f, 0.5294118f);
        
        private readonly Color _colorBackground;
        private readonly Action<LoggerWindowLog> _onClick;
        
        private bool _isSelected;
        
        public LoggerWindowLog(string logText, Color colorBackground, Action<LoggerWindowLog> onClick)
        {
            _colorBackground = colorBackground;
            _onClick = onClick;
            
            text = logText;
            style.backgroundColor = colorBackground;
            style.minHeight = 40;
            style.color = Color.white;
            style.paddingLeft = 20;
            style.unityTextAlign = TextAnchor.MiddleLeft;
            
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
            style.backgroundColor = _isSelected ? SelectedColor : _colorBackground;
        }
    }
}