using OpenMyGame.LoggerUnity.Editor.ConfigsEditor;
using OpenMyGame.LoggerUnity.Editor.TagsWindow;
using OpenMyGame.LoggerUnity.Tagging.Colors.ViewConfig;
using UnityEditor;
using Object = UnityEngine.Object;

namespace OpenMyGame.LoggerUnity.Editor.ViewConfig
{
    public class LoggerWindowViewConfigEditorWindow : ConfigEditorWindowBase
    {
        private const string WindowDescription = "View config editor";

        [MenuItem("Logger/Show logger window view config editor")]
        public static void Open()
        {
            GetWindow<LoggerWindowViewConfigEditorWindow>(WindowDescription);
        }

        protected override Object GetEditingObject()
        {
            return LoggerWindowViewConfig.Load();
        }
    }
}