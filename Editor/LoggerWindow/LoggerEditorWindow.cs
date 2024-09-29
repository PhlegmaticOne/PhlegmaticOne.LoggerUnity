using OpenMyGame.LoggerUnity.Editor.Base.Styles;
using OpenMyGame.LoggerUnity.Editor.LoggerWindow.ViewConfig;
using UnityEditor;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.Editor.LoggerWindow
{
    public class LoggerEditorWindow : EditorWindow
    {
        private LoggerEditorWindowView _windowView;

        [MenuItem("Logger/Show log window")]
        private static void ShowLogWindow()
        {
            var window = (LoggerEditorWindow)GetWindow(typeof(LoggerEditorWindow));
            window.minSize = LoggerWindowConstantStyles.MinWindowSize;
            window.wantsLessLayoutEvents = true;
            window.titleContent = new GUIContent(LoggerWindowConstantStyles.WindowTitle);
            window.Show();
        }

        private void CreateGUI()
        {
            var config = LoggerWindowViewConfig.Load();
            _windowView = new LoggerEditorWindowView(this, rootVisualElement, config);
            _windowView.CreateView();
        }

        private void OnGUI()
        {
            _windowView?.UpdateView();
        }
    }
}