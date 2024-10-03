using OpenMyGame.LoggerUnity.Editor.Base.Extensions;
using UnityEngine.UIElements;

namespace OpenMyGame.LoggerUnity.Editor.LoggerWindow.Controls
{
    internal class LoggerWindowRootScroll : ScrollView
    {
        public LoggerWindowRootScroll(params VisualElement[] children) : base(ScrollViewMode.Vertical)
        {
            horizontalScrollerVisibility = ScrollerVisibility.Hidden;
            verticalScrollerVisibility = ScrollerVisibility.Hidden;
            mouseWheelScrollSize = 0;

            this.AddChildren(children);
        }
    }
}