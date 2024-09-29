using OpenMyGame.LoggerUnity.Editor.LoggerWindow.Controls;
using OpenMyGame.LoggerUnity.Editor.ViewConfig;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace OpenMyGame.LoggerUnity.Editor.LoggerWindow
{
    public class LoggerEditorWindowView
    {
        private readonly VisualElement _rootElement;
        private readonly EditorWindow _window;
        private readonly LoggerWindowViewConfig _viewConfig;

        private LoggerWindowToolbar _toolBar;
        private LoggerWindowTagsBar _tagsBar;
        private LoggerWindowLogsScroll _logsScroll;
        private LoggerWindowLogInspector _logInspector;

        public LoggerEditorWindowView(
            EditorWindow window, 
            VisualElement rootElement, 
            LoggerWindowViewConfig viewConfig)
        {
            _rootElement = rootElement;
            _window = window;
            _viewConfig = viewConfig;
        }
        
        public void CreateView()
        {
            var rootScroll = new LoggerWindowRootScroll(
                _toolBar = new LoggerWindowToolbar(_viewConfig),
                _tagsBar = new LoggerWindowTagsBar(),
                _logsScroll = new LoggerWindowLogsScroll(_viewConfig));
            
            _logInspector = new LoggerWindowLogInspector(_viewConfig);
            
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
            
            RecalculateLogControlHeights(windowHeight, toolBarHeight, tagsBarHeight);
            RecalculateSearchbarWidth();
        }

        private void RecalculateSearchbarWidth()
        {
            _toolBar.SetSearchbarWidth(_window.position.width);
        }

        private void RecalculateLogControlHeights(float windowHeight, float toolBarHeight, float tagsBarHeight)
        {
            var labelHeight = Mathf.Max(0, windowHeight * _viewConfig.SelectedLogWindowSizePercent);
            var height = Mathf.Max(0, windowHeight - toolBarHeight - tagsBarHeight - labelHeight);
            
            _logInspector.style.height = labelHeight;
            _logsScroll.style.height = height;
        }
    }
}