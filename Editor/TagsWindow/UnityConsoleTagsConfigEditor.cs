using OpenMyGame.LoggerUnity.Editor.ConfigsEditor;
using OpenMyGame.LoggerUnity.Runtime.Tagging.Colors.ViewConfig;
using UnityEditor;
using Object = UnityEngine.Object;

namespace OpenMyGame.LoggerUnity.Editor.TagsWindow
{
    public class UnityConsoleTagsConfigEditor : ConfigEditorWindowBase
    {
        private const string WindowDescription = "Tags editor";

        [MenuItem("Logger/Show tags editor")]
        public static void Open()
        {
            GetWindow<UnityConsoleTagsConfigEditor>(WindowDescription);
        }

        protected override Object GetEditingObject()
        {
            return TagColorsViewConfig.Load();
        }
    }
}