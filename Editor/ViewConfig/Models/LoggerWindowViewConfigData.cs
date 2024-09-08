using System;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.Editor.ViewConfig.Models
{
    [Serializable]
    public class LoggerWindowViewConfigData
    {
        [Header("Log entries configs")]
        [SerializeField] private LoggerWindowColorConfigData[] _debugColors;
        [SerializeField] private LoggerWindowColorConfigData _warningColor;
        [SerializeField] private LoggerWindowColorConfigData _errorColor;
        [SerializeField] private LoggerWindowColorConfigData _fatalColor;
        [SerializeField] private LoggerWindowColorConfigData _selectedLogColor;
        [SerializeField] private LoggerWindowColorConfigData _logInspectorColor;

        [Header("Toggle configs")]
        [SerializeField] private LoggerWindowLogLevelToggleConfigData _debugToggle;
        [SerializeField] private LoggerWindowLogLevelToggleConfigData _warningToggle;
        [SerializeField] private LoggerWindowLogLevelToggleConfigData _errorToggle;
        [SerializeField] private LoggerWindowLogLevelToggleConfigData _fatalToggle;
        
        [Header("Sizing config")] 
        [SerializeField]
        [Range(0.05f, 0.6f)]
        private float _selectedLogWindowSizePercent;

        public LoggerWindowColorConfigData[] DebugColors => _debugColors;
        public LoggerWindowColorConfigData WarningColor => _warningColor;
        public LoggerWindowColorConfigData ErrorColor => _errorColor;
        public LoggerWindowColorConfigData FatalColor => _fatalColor;
        public LoggerWindowColorConfigData SelectedLogColor => _selectedLogColor;
        public LoggerWindowColorConfigData LogInspectorColor => _logInspectorColor;

        public LoggerWindowLogLevelToggleConfigData DebugToggle => _debugToggle;
        public LoggerWindowLogLevelToggleConfigData WarningToggle => _warningToggle;
        public LoggerWindowLogLevelToggleConfigData ErrorToggle => _errorToggle;
        public LoggerWindowLogLevelToggleConfigData FatalToggle => _fatalToggle;

        public float SelectedLogWindowSizePercent => _selectedLogWindowSizePercent;
    }
}