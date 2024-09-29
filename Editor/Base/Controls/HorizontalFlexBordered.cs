using OpenMyGame.LoggerUnity.Editor.Base.Extensions;
using OpenMyGame.LoggerUnity.Editor.Base.Styles;
using UnityEngine.UIElements;

namespace OpenMyGame.LoggerUnity.Editor.Base.Controls
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