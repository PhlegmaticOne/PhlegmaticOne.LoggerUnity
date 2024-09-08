using OpenMyGame.LoggerUnity.Editor.LoggerWindow.Components.Extensions;
using UnityEngine;
using UnityEngine.UIElements;

namespace OpenMyGame.LoggerUnity.Editor.LoggerWindow.Components.Base
{
    public class HorizontalFlexBordered : HorizontalFlex
    {
        public HorizontalFlexBordered(Justify justify, params VisualElement[] elements) : base(justify, elements)
        {
            this.AddBorder();
            style.backgroundColor = new StyleColor(new Color(0.23f, 0.23f, 0.23f));
        }
    }
}