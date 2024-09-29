using OpenMyGame.LoggerUnity.Editor.Base.Windows;
using UnityEditor;
using Object = UnityEngine.Object;

namespace OpenMyGame.LoggerUnity.Editor.LoggerWindow.ViewConfig
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