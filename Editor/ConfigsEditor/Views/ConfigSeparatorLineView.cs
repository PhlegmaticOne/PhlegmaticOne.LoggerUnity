using UnityEditor;
using UnityEngine;

namespace Openmygame.Logger.Editor.ConfigsEditor.Views
{
    public class ConfigSeparatorLineView
    {
        public void Draw()
        {
            EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
        }
    }
}