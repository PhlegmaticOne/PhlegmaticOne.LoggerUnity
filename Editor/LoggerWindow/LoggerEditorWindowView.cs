using OpenMyGame.LoggerUnity.Editor.LoggerWindow.Controls;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace OpenMyGame.LoggerUnity.Editor.LoggerWindow
{
    public class LoggerEditorWindowView
    {
        private readonly VisualElement _rootElement;
        private readonly EditorWindow _window;
        
        private LoggerWindowToolbar _toolBar;
        private LoggerWindowTagsBar _tagsBar;
        private LoggerWindowLogsScroll _logsScroll;
        private LoggerWindowLogInspector _logInspector;

        public LoggerEditorWindowView(VisualElement rootElement, EditorWindow window)
        {
            _rootElement = rootElement;
            _window = window;
        }
        
        public void CreateView()
        {
            var rootScroll = new LoggerWindowRootScroll(
                _toolBar = new LoggerWindowToolbar(),
                _tagsBar = new LoggerWindowTagsBar(),
                _logsScroll = new LoggerWindowLogsScroll());
            
            _logInspector = new LoggerWindowLogInspector();
            
            _rootElement.Add(rootScroll);
            _rootElement.Add(_logInspector);
        }

        public void UpdateView()
        {
            var windowHeight = _window.position.height;
            var toolBarHeight = _toolBar.layout.height;
            var tagsBarHeight = _tagsBar.layout.height;
            
            if (float.IsNaN(windowHeight) || float.IsNaN(toolBarHeight) || float.IsNaN(tagsBarHeight))
            {
                return;
            }
            
            var labelHeight = Mathf.Max(0, windowHeight / 4);
            var height = Mathf.Max(0, windowHeight - toolBarHeight - tagsBarHeight - labelHeight);
            
            _logInspector.style.height = labelHeight;
            _logsScroll.style.height = height;
        }
    }
}