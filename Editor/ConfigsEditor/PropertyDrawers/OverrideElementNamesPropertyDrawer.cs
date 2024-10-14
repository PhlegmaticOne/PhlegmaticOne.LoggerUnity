using OpenMyGame.LoggerUnity.Attributes;
using UnityEditor;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.Editor.ConfigsEditor.PropertyDrawers
{
    [CustomPropertyDrawer(typeof(OverrideElementNamesAttribute))]
    public class OverrideElementNamesPropertyDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUI.GetPropertyHeight(property, label, true);
        }

        public override void OnGUI(Rect rect, SerializedProperty property, GUIContent label)
        {
            try 
            {
                var propertyValue = property.boxedValue;
                var value = propertyValue?.ToString() ?? string.Empty;
                var overridenName = string.IsNullOrEmpty(value) ? property.displayName : value;
                EditorGUI.PropertyField(rect, property, new GUIContent(overridenName), true);
            } 
            catch 
            {
                EditorGUI.PropertyField(rect, property, label, true);
            }
        }
    }
}