using OpenMyGame.LoggerUnity.Editor.ViewConfig.Models;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.Editor.ViewConfig
{
    public class LoggerWindowViewConfig : ScriptableObject
    {
        private const string LoggerWindowViewConfigPath = "LoggerWindowViewConfig";

        internal const string PropertyName = nameof(_configData);

        [SerializeField] private LoggerWindowViewConfigData _configData;

        public LoggerWindowViewConfigData ConfigData => _configData;

        internal static LoggerWindowViewConfig Load()
        {
            return Resources.Load<LoggerWindowViewConfig>(LoggerWindowViewConfigPath);
        }
    }
}