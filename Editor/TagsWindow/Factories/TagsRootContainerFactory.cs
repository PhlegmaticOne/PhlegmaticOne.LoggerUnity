using OpenMyGame.LoggerUnity.Editor.LoggerWindow.Components.Base;
using OpenMyGame.LoggerUnity.Editor.LoggerWindow.Styles;
using UnityEngine.UIElements;

namespace OpenMyGame.LoggerUnity.Editor.TagsWindow.Factories
{
    public class TagsRootContainerFactory : ITagsRootContainerFactory
    {
        public VisualElement CreateRootContainer()
        {
            return new HorizontalFlex(Justify.FlexStart)
            {
                style =
                {
                    paddingTop = 5,
                    paddingBottom = 5,
                    paddingLeft = 5,
                    paddingRight = 5,
                    minHeight = LoggerWindowConstantStyles.ToolbarHeight
                }
            };
        }
    }
}