using System;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.Editor.LoggerWindow.ViewConfig.Models
{
    [Serializable]
    public struct LoggerWindowLogLevelToggleConfigData
    {
        [SerializeField] private Color _color;
        [SerializeField] private string _text;

        public Color Color => _color;
        public string Text => _text;
    }
}