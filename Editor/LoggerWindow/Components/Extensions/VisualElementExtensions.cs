using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace OpenMyGame.LoggerUnity.Editor.LoggerWindow.Components.Extensions
{
    public static class VisualElementExtensions
    {
        public static T AddBorder<T>(this T element) where T : VisualElement
        {
            element.style.borderBottomWidth = 1;
            element.style.borderTopWidth = 1;
            element.style.borderLeftWidth = 1;
            element.style.borderRightWidth = 1;
            element.style.borderBottomColor = new StyleColor(new Color(0.13f, 0.13f, 0.13f));
            element.style.borderTopColor = new StyleColor(new Color(0.13f, 0.13f, 0.13f));
            element.style.borderRightColor = new StyleColor(new Color(0.13f, 0.13f, 0.13f));
            element.style.borderLeftColor = new StyleColor(new Color(0.13f, 0.13f, 0.13f));
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