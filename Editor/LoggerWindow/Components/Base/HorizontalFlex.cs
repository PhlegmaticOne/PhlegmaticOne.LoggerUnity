using OpenMyGame.LoggerUnity.Editor.LoggerWindow.Components.Extensions;
using UnityEngine.UIElements;

namespace OpenMyGame.LoggerUnity.Editor.LoggerWindow.Components.Base
{
    public class HorizontalFlex : VisualElement
    {
        public HorizontalFlex(Justify justify, params VisualElement[] elements)
        {
            style.display = DisplayStyle.Flex;
            style.flexDirection = FlexDirection.Row;
            style.flexWrap = Wrap.Wrap;
            style.justifyContent = justify;
            
            this.AddChildren(elements);
        }
    }
}