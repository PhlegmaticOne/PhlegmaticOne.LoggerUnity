using UnityEditor;
using Object = UnityEngine.Object;

namespace OpenMyGame.LoggerUnity.Editor.ConfigsEditor
{
    public abstract class ConfigEditorWindowBase : EditorWindow
    {
        private UnityEditor.Editor _configEditor;
        
        private void CreateGUI()
        {
            var editingObject = GetEditingObject();
            _configEditor = UnityEditor.Editor.CreateEditor(editingObject);
        }

        private void OnGUI()
        {
            _configEditor.OnInspectorGUI();
        }

        protected abstract Object GetEditingObject();
    }
}