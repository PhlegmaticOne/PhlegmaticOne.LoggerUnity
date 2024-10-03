using OpenMyGame.LoggerUnity.Editor.LoggerWindow.ViewConfig;
using UnityEngine.UIElements;

namespace OpenMyGame.LoggerUnity.Editor.LoggerWindow.Controls
{
    internal sealed class LoggerWindowLogInspector : TextElement
    {
        public LoggerWindowLogInspector(LoggerWindowViewConfig viewConfig)
        {
            UpdateStyles(viewConfig);
        }

        public void Inspect(string logText)
        {
            text = logText;
        }

        private void UpdateStyles(LoggerWindowViewConfig viewConfig)
        {
            style.height = 100;

            var logInspectorColor = viewConfig.LogInspectorColor;
            style.color = logInspectorColor.TextColor;
            style.backgroundColor = logInspectorColor.BackgroundColor;
        }
    }
}