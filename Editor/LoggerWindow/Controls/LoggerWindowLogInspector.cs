using OpenMyGame.LoggerUnity.Editor.ViewConfig;
using UnityEngine.UIElements;

namespace OpenMyGame.LoggerUnity.Editor.LoggerWindow.Controls
{
    public sealed class LoggerWindowLogInspector : TextElement
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

            var logInspectorColor = viewConfig.ConfigData.LogInspectorColor;
            style.color = logInspectorColor.TextColor;
            style.backgroundColor = logInspectorColor.BackgroundColor;
        }
    }
}