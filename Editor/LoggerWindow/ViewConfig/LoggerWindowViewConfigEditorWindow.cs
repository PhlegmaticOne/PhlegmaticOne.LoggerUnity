using OpenMyGame.LoggerUnity.Editor.Base.Windows;
using UnityEditor;

namespace OpenMyGame.LoggerUnity.Editor.LoggerWindow.ViewConfig
{
    public class LoggerWindowViewConfigEditorWindow : ConfigEditorWindowBase<LoggerWindowViewConfig>
    {
        private const string WindowDescription = "View config editor";

        protected override string ConfigName => "LoggerWindowViewConfig";
        protected override string CreateDescription => "Create logger window view config";
        
        [MenuItem("Logger/Show logger window view config editor")]
        public static void Open()
        {
            GetWindow<LoggerWindowViewConfigEditorWindow>(WindowDescription);
        }
    }
}