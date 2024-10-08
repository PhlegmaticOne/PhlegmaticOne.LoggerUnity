﻿using System;
using System.Collections.Generic;
using OpenMyGame.LoggerUnity.Editor.TagsWindow.Models;
using OpenMyGame.LoggerUnity.Editor.TagsWindow.Views.Factories;
using UnityEngine.UIElements;

namespace OpenMyGame.LoggerUnity.Editor.TagsWindow.Views
{
    internal class UnityConsoleTagsControl : ScrollView
    {
        private readonly UnityConsoleTagsBar _tagsBar;

        public event Action<TagClickEventArgs> TagClicked; 
        
        public UnityConsoleTagsControl(
            ITagsRootContainerFactory rootContainerFactory,
            ITagControlFactory tagControlFactory) : base(ScrollViewMode.Vertical)
        {
            style.height = new StyleLength(Length.Percent(100));
            this.AddManipulator(new Clickable(HandleEmptySpaceClicked));
            _tagsBar = new UnityConsoleTagsBar(rootContainerFactory, tagControlFactory);
            _tagsBar.TagClicked += OnTagClicked;
            Add(_tagsBar);
        }

        public void RepaintTags(ICollection<TagViewModel> availableTags)
        {
            _tagsBar.RepaintTags(availableTags);
        }

        public void ClearTags()
        {
            _tagsBar.ClearTags();
        }

        private void OnTagClicked(TagClickEventArgs tagClick)
        {
            TagClicked?.Invoke(tagClick);
        }

        private void HandleEmptySpaceClicked()
        {
            _tagsBar.SetAllTagsInactive();
        }
    }
}