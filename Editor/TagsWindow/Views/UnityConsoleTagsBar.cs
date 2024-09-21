using System;
using System.Collections.Generic;
using OpenMyGame.LoggerUnity.Editor.LoggerWindow.Components;
using OpenMyGame.LoggerUnity.Editor.LoggerWindow.Controls.EventData;
using OpenMyGame.LoggerUnity.Editor.TagsWindow.Factories;
using UnityEngine.UIElements;

namespace OpenMyGame.LoggerUnity.Editor.TagsWindow.Views
{
    public class UnityConsoleTagsBar : ScrollView
    {
        private readonly ITagControlFactory _tagControlFactory;
        private readonly List<LoggerWindowToggle> _tagControls;
        private readonly VisualElement _tagsRootContainer;

        public event Action<TagClickEventArgs> TagClicked;
        
        public UnityConsoleTagsBar(
            ITagsRootContainerFactory rootContainerFactory,
            ITagControlFactory tagControlFactory) : base(ScrollViewMode.Vertical)
        {
            _tagControlFactory = tagControlFactory;
            verticalScrollerVisibility = ScrollerVisibility.Hidden;
            horizontalScrollerVisibility = ScrollerVisibility.Hidden;
            _tagControls = new List<LoggerWindowToggle>();
            _tagsRootContainer = rootContainerFactory.CreateRootContainer();
            
            Add(_tagsRootContainer);
            this.AddManipulator(new Clickable(SetAllTagsInactive));
        }

        public void RepaintTags(ICollection<string> availableTags)
        {
            var index = 0;

            foreach (var tag in availableTags)
            {
                if (index < _tagControls.Count)
                {
                    _tagControls[index].ChangeText(tag);
                }
                else
                {
                    AddTag(tag);
                }

                index++;
            }
        }

        public void ClearTags()
        {
            _tagControls.Clear();
            _tagsRootContainer.Clear();
        }

        public void SetAllTagsInactive()
        {
            foreach (var tagToggle in _tagControls)
            {
                tagToggle.SetValueWithoutNotify(false);
            }
            
            OnTagClicked(new TagClickEventArgs(string.Empty, false));
        }

        private void AddTag(string tag)
        {
            var tagControl = _tagControlFactory.CreateTagControl(tag, OnTagClicked);
            _tagsRootContainer.Add(tagControl);
            _tagControls.Add(tagControl);
        }

        private void OnTagClicked(LoggerWindowToggle toggle, bool isActive)
        {
            if (isActive)
            {
                SetOtherTagsInactive(toggle);
            }
            
            OnTagClicked(new TagClickEventArgs(toggle.Text, isActive));
        }

        private void OnTagClicked(TagClickEventArgs tagClickEventArgs)
        {
            if (_tagControls.Count > 0)
            {
                TagClicked?.Invoke(tagClickEventArgs);
            }
        }

        private void SetOtherTagsInactive(LoggerWindowToggle toggle)
        {
            foreach (var tagToggle in _tagControls)
            {
                if (tagToggle != toggle)
                {
                    tagToggle.SetValueWithoutNotify(false);
                }
            }
        }
    }
}