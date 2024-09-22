using OpenMyGame.LoggerUnity.Editor.TagsWindow.Views.Components;
using OpenMyGame.LoggerUnity.Editor.TagsWindow.Views.Extensions;
using OpenMyGame.LoggerUnity.Editor.TagsWindow.Views.Styles;
using UnityEngine.UIElements;

namespace OpenMyGame.LoggerUnity.Editor.LoggerWindow.Components
{
    public class HorizontalFlexBordered : HorizontalFlex
    {
        public HorizontalFlexBordered(Justify justify, params VisualElement[] elements) : base(justify, elements)
        {
            this.AddBorder();
            style.backgroundColor = new StyleColor(LoggerWindowConstantStyles.ToolbarBackgroundColor);
        }
    }
}