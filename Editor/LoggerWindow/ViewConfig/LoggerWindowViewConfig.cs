using OpenMyGame.LoggerUnity.Editor.LoggerWindow.ViewConfig.Models;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.Editor.LoggerWindow.ViewConfig
{
    [CreateAssetMenu(menuName = "Test", fileName = "LoggerWindowViewConfig")]
    public class LoggerWindowViewConfig : ScriptableObject
    {
        [Header("Log entries configs")]
        [SerializeField] private LoggerWindowColorConfigData[] _debugColors;
        [SerializeField] private LoggerWindowColorConfigData _warningColor;
        [SerializeField] private LoggerWindowColorConfigData _errorColor;
        [SerializeField] private LoggerWindowColorConfigData _fatalColor;
        [SerializeField] private LoggerWindowColorConfigData _selectedLogColor;
        [SerializeField] private LoggerWindowColorConfigData _logInspectorColor;

        [Header("Sizing config")] 
        [SerializeField]
        [Range(0.05f, 0.6f)]
        private float _selectedLogWindowSizePercent;

        internal static LoggerWindowViewConfig Load()
        {
            return Resources.Load<LoggerWindowViewConfig>("LoggerWindowViewConfig");
        }

        public LoggerWindowColorConfigData[] DebugColors => _debugColors;
        public LoggerWindowColorConfigData WarningColor => _warningColor;
        public LoggerWindowColorConfigData ErrorColor => _errorColor;
        public LoggerWindowColorConfigData FatalColor => _fatalColor;
        public LoggerWindowColorConfigData SelectedLogColor => _selectedLogColor;
        public LoggerWindowColorConfigData LogInspectorColor => _logInspectorColor;

        public float SelectedLogWindowSizePercent => _selectedLogWindowSizePercent;
    }
}