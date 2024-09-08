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
            window.minSize = new Vector2(310, 500);
            window.wantsLessLayoutEvents = true;
            window.titleContent = new GUIContent("Logger window");
            window.Show();
        }

        private void CreateGUI()
        {
            Debug.Log("test");
            Debug.Log("test");
            Debug.Log("test");
            _windowView = new LoggerEditorWindowView(rootVisualElement, this);
            _windowView.CreateView();
        }

        private void OnGUI()
        {
            _windowView.UpdateView();
        }

        // private static void Test(
        //     [CallerFilePath] string filePath = "",
        //     [CallerLineNumber] int lineNumber = 0)
        // {
        //     rider64.exe [--line <number>] [--column <number>] <path ...>
        //     Debug.Log(filePath + lineNumber);
        // }
    }
}