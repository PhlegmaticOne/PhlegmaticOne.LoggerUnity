using UnityEditor;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.Editor.ConfigsEditor.Views
{
    public class ConfigSeparatorLineView
    {
        public void Draw()
        {
            EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
        }
    }
}