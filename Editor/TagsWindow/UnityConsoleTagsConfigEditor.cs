using OpenMyGame.LoggerUnity.Editor.ConfigsEditor;
using OpenMyGame.LoggerUnity.Tagging.Colors.ViewConfig;
using UnityEditor;

namespace OpenMyGame.LoggerUnity.Editor.TagsWindow
{
    public class UnityConsoleTagsConfigEditor : ConfigEditorWindowBase<TagColorsViewConfig>
    {
        private const string WindowDescription = "Tags editor";

        protected override string ConfigName => "TagColorsViewConfig";
        protected override string CreateDescription => "Create tag colors config";

        [MenuItem("Logger/Show tags editor")]
        public static void Open()
        {
            GetWindow<UnityConsoleTagsConfigEditor>(WindowDescription);
        }
    }
}