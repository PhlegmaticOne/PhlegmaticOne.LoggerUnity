using UnityEditor;
using UnityEngine;

namespace Openmygame.Logger.Editor.ConfigsEditor.Views
{
    internal class ConfigNameView
    {
        private readonly GUIStyle _style;

        public ConfigNameView()
        {
            _style = new GUIStyle
            {
                fontSize = 16,
                fontStyle = FontStyle.Bold,
                normal =
                {
                    textColor = new Color(0.9607844f, 0.8745099f, 0.7098039f)
                }
            };
        }

        public void Draw(string configName)
        {
            EditorGUILayout.LabelField(configName, _style);
        }
    }
}