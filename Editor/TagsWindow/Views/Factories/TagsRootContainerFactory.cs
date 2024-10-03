using OpenMyGame.LoggerUnity.Editor.Base.Controls;
using OpenMyGame.LoggerUnity.Editor.Base.Styles;
using UnityEngine.UIElements;

namespace OpenMyGame.LoggerUnity.Editor.TagsWindow.Views.Factories
{
    internal class TagsRootContainerFactory : ITagsRootContainerFactory
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