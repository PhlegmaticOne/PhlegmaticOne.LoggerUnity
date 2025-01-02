using System;
using Openmygame.Logger.Configuration.Attributes;
using Openmygame.Logger.Configuration.Base;
using Object = UnityEngine.Object;

namespace Openmygame.Logger.Editor.ConfigsEditor.Models
{
    internal class LoggerConfigViewModel
    {
        private readonly LoggerConfigMetadataAttribute _configAttribute;
        
        private LoggerConfigBase _instance;
        private UnityEditor.Editor _editor;

        public Type ConfigType { get; }
        public string Name => _configAttribute.ConfigName;
        public string CreateDescription => _configAttribute.CreateDescription;
        public int OrderInEditor => _configAttribute.OrderInEditor;
        
        public bool IsCreated => _instance != null;

        public LoggerConfigViewModel(LoggerConfigMetadataAttribute configAttribute, Type configType, LoggerConfigBase config = null)
        {
            ConfigType = configType;
            _configAttribute = configAttribute;
            SetConfig(config);
        }

        public void SetConfig(LoggerConfigBase loggerConfig)
        {
            _instance = loggerConfig;
            EnsureEditorCreated();
        }

        public void HandleRedraw()
        {
            if (_instance != null)
            {
                _editor.OnInspectorGUI();
                return;
            }
            
            if (_instance == null && _editor != null)
            {
                Object.DestroyImmediate(_editor);
            }
        }
        
        private void EnsureEditorCreated()
        {
            if (_instance is not null)
            {
                _editor = UnityEditor.Editor.CreateEditor(_instance);
            }
        }
    }
}