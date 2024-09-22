using UnityEditor;

namespace OpenMyGame.LoggerUnity.Editor.ViewConfig.Window
{
    public class LoggerWindowViewConfigEditorWindow : EditorWindow
    {
        private const string WindowDescription = "Logger view config editor";
        
        private SerializedObject _serializedObject;
        
        [MenuItem("Logger/Show view config editor")]
        public static void Open()
        {
            var config = LoggerWindowViewConfig.Load();
            var window = GetWindow<LoggerWindowViewConfigEditorWindow>(WindowDescription);
            window._serializedObject = new SerializedObject(config);
        }

        private void OnGUI()
        {
            var property = _serializedObject.FindProperty(LoggerWindowViewConfig.PropertyName);
            DrawProperties(property);
            _serializedObject.ApplyModifiedProperties();
        }

        private static void DrawProperties(SerializedProperty property, bool drawArrayElements = false)
        {
            var lastPropertyPath = string.Empty;

            foreach (SerializedProperty child in property)
            {
                if (PropertyIsArray(child))
                {
                    DrawArray(child);
                    continue;
                }

                if (ShouldSkipProperty(lastPropertyPath, child, drawArrayElements))
                {
                    continue;
                }

                lastPropertyPath = child.propertyPath;
                EditorGUILayout.PropertyField(child, true);
            }
        }

        private static bool PropertyIsArray(SerializedProperty property)
        {
            return property.isArray && property.propertyType == SerializedPropertyType.Generic;
        }

        private static void DrawArray(SerializedProperty property)
        {
            EditorGUILayout.BeginHorizontal();
            property.isExpanded = EditorGUILayout.Foldout(property.isExpanded, property.displayName);
            EditorGUILayout.EndHorizontal();

            if (property.isExpanded)
            {
                EditorGUI.indentLevel++;
                DrawProperties(property, true);
                EditorGUI.indentLevel--;
            }
        }

        private static bool ShouldSkipProperty(
            string lastPropertyPath, SerializedProperty property, bool drawArrayElements)
        {
            if (!string.IsNullOrEmpty(lastPropertyPath) && property.propertyPath.Contains(lastPropertyPath))
            {
                return true;
            }
        
            return property.propertyPath.Contains("Array") && !drawArrayElements;
        }
    }
}