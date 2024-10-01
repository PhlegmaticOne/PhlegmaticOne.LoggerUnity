using OpenMyGame.LoggerUnity.Editor.ConfigsEditor;
using UnityEditor;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.Editor.Base.Windows
{
    public abstract class ConfigEditorWindowBase<T> : EditorWindow where T : ScriptableObject
    {
        private Vector2 _scrollPosition;
        private UnityEditor.Editor _configEditor;
        private bool _isCreated;
        
        protected abstract string ConfigName { get; }
        protected abstract string CreateDescription { get; }
        
        private void CreateGUI()
        {
            var config = ConfigEditorWindowHelper.LoadConfig<T>(ConfigName);
            
            if (config != null)
            {
                CreateConfigEditor(config);
            }
            else
            {
                _isCreated = false;
            }
        }

        private void OnGUI()
        {
            if (_isCreated)
            {
                DrawConfigEditor();
            }
            else
            {
                DrawConfigCreateMenu();
            }
        }

        private void CreateConfigEditor(T editingObject)
        {
            _configEditor = UnityEditor.Editor.CreateEditor(editingObject);
            _isCreated = true;
        }

        private void DrawConfigEditor()
        {
            _scrollPosition = EditorGUILayout.BeginScrollView(_scrollPosition);
            _configEditor.OnInspectorGUI();
            EditorGUILayout.EndScrollView();
        }

        private void DrawConfigCreateMenu()
        {
            if (GUILayout.Button(CreateDescription))
            {
                var config = ConfigEditorWindowHelper.CreateConfig<T>(ConfigName);
                CreateConfigEditor(config);
            }
        }
    }
}