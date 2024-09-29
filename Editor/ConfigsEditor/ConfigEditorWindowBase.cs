using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace OpenMyGame.LoggerUnity.Editor.ConfigsEditor
{
    public abstract class ConfigEditorWindowBase : EditorWindow
    {
        private Vector2 _scrollPosition;
        private UnityEditor.Editor _configEditor;
        
        private void CreateGUI()
        {
            var editingObject = GetEditingObject();
            _configEditor = UnityEditor.Editor.CreateEditor(editingObject);
        }

        private void OnGUI()
        {
            _scrollPosition = EditorGUILayout.BeginScrollView(_scrollPosition);
            _configEditor.OnInspectorGUI();
            EditorGUILayout.EndScrollView();
        }

        protected abstract Object GetEditingObject();
    }
}