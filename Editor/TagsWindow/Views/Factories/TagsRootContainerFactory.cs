using OpenMyGame.LoggerUnity.Editor.TagsWindow.Views.Components;
using OpenMyGame.LoggerUnity.Editor.TagsWindow.Views.Styles;
using UnityEngine.UIElements;

namespace OpenMyGame.LoggerUnity.Editor.TagsWindow.Views.Factories
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