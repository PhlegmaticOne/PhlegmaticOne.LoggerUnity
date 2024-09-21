using OpenMyGame.LoggerUnity.Editor.LoggerWindow.Controls.EventData;
using OpenMyGame.LoggerUnity.Editor.TagsWindow.Factories;
using OpenMyGame.LoggerUnity.Editor.TagsWindow.Models;
using OpenMyGame.LoggerUnity.Editor.TagsWindow.Views;
using UnityEditor;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.Editor.TagsWindow
{
    public class UnityConsoleTagsWindow : EditorWindow
    {
        private static ITagsSource TagsSource;
        
        private UnityConsoleTagsControl _tagsControl;

        [MenuItem("Logger/Show console tags window")]
        private static void ShowLogWindow()
        {
            var window = GetWindow<UnityConsoleTagsWindow>();
            window.titleContent = new GUIContent("Tags");
            window.Show();
        }

        [RuntimeInitializeOnLoadMethod]
        public static void Test()
        {
            TagsSource = new TagsSource();
        }

        private void CreateGUI()
        {
            _tagsControl = new UnityConsoleTagsControl(
                new TagsRootContainerFactory(),
                new TagControlFactory());
            
            _tagsControl.TagClicked += OnTagClicked;
            
            rootVisualElement.Add(_tagsControl);
        }

        private void Update()
        {
            if (TagsSource is null || !TagsSource.HasChanges || _tagsControl == null)
            {
                return;
            }

            var availableTags = TagsSource.GetAvailableTags();
            _tagsControl.RepaintTags(availableTags);
        }

        private static void OnTagClicked(TagClickEventArgs tagClick)
        {
            var tag = !tagClick.IsActive ? string.Empty : tagClick.Tag;
            TagsSource.SetTagFilter(tag);
        }
    }
}