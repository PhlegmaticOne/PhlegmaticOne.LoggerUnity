using System;
using OpenMyGame.LoggerUnity.Editor.Base.Controls;
using OpenMyGame.LoggerUnity.Editor.Base.Extensions;
using OpenMyGame.LoggerUnity.Editor.Base.Styles;
using OpenMyGame.LoggerUnity.Editor.LoggerWindow.Components;
using OpenMyGame.LoggerUnity.Editor.TagsWindow.Models;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace OpenMyGame.LoggerUnity.Editor.LoggerWindow.Controls
{
    public class LoggerWindowTagsBar : ScrollView
    {
        private readonly VisualElement _tagsBar;

        public event Action<TagClickEventArgs> TagClicked;
        
        public LoggerWindowTagsBar() : base(ScrollViewMode.Vertical)
        {
            verticalScrollerVisibility = ScrollerVisibility.Hidden;
            horizontalScrollerVisibility = ScrollerVisibility.Hidden;
            
            Add(_tagsBar = TagBar());
        }

        public void AddTag(string tag)
        {
            _tagsBar.Add(CreateTagElement(tag));
        }

        private void OnTagClicked(string tag, bool isActive)
        {
            TagClicked?.Invoke(new TagClickEventArgs(tag, isActive));
        }

        private ToolbarToggle CreateTagElement(string tag)
        {
            return new LoggerWindowToggle(tag, Color.white, (toggle, e) => OnTagClicked(tag, e))
                .WithStyle(x => x.AddMargin(1))
                .WithStyle(x => x.height = LoggerWindowConstantStyles.ToolbarHeight);
        }

        private static VisualElement TagBar()
        {
            var tagBar = new HorizontalFlexBordered(Justify.FlexStart)
            {
                style =
                {
                    marginTop = -1,
                    paddingLeft = 5,
                    paddingRight = 5,
                    minHeight = LoggerWindowConstantStyles.ToolbarHeight
                }
            };

            return tagBar;
        }
    }
}