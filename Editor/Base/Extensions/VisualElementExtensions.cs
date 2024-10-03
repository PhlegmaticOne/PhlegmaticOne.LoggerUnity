using System;
using OpenMyGame.LoggerUnity.Editor.Base.Styles;
using UnityEngine.UIElements;

namespace OpenMyGame.LoggerUnity.Editor.Base.Extensions
{
    internal static class VisualElementExtensions
    {
        public static T AddBorder<T>(this T element, int borderWidth = 1) where T : VisualElement
        {
            var borderStyleColor = new StyleColor(LoggerWindowConstantStyles.BorderColor);
            
            element.style.borderBottomWidth = borderWidth;
            element.style.borderTopWidth = borderWidth;
            element.style.borderLeftWidth = borderWidth;
            element.style.borderRightWidth = borderWidth;
            
            element.style.borderBottomColor = borderStyleColor;
            element.style.borderTopColor = borderStyleColor;
            element.style.borderRightColor = borderStyleColor;
            element.style.borderLeftColor = borderStyleColor;
            
            return element;
        }
        
        public static void AddChildren(this VisualElement element, params VisualElement[] children)
        {
            foreach (var child in children)
            {
                element.Add(child);
            }
        }

        public static void AddMargin(this IStyle style, int margin)
        {
            style.marginLeft = margin;
            style.marginRight = margin;
            style.marginTop = margin;
            style.marginBottom = margin;
        }
        
        public static T WithStyle<T>(this T element, Action<IStyle> styleAction) where T : VisualElement
        {
            styleAction(element.style);
            return element;
        }
    }
}