using UnityEngine.UIElements;

namespace OpenMyGame.LoggerUnity.Editor.LoggerWindow.Controls
{
    public sealed class LoggerWindowLogInspector : TextElement
    {
        public LoggerWindowLogInspector()
        {
            style.height = 100;
        }

        public void Inspect(string logText)
        {
            text = logText;
        }
    }
}