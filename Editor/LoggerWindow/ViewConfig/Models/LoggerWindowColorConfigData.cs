using System;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.Editor.LoggerWindow.ViewConfig.Models
{
    [Serializable]
    public struct LoggerWindowColorConfigData
    {
        [SerializeField] private Color _backgroundColor;
        [SerializeField] private Color _textColor;

        public Color BackgroundColor => _backgroundColor;
        public Color TextColor => _textColor;
    }
}