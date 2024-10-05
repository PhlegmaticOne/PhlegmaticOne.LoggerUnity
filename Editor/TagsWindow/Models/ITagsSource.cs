using System.Collections.Generic;

namespace OpenMyGame.LoggerUnity.Editor.TagsWindow.Models
{
    internal interface ITagsSource
    {
        bool HasChanges { get; }
        void SetTagFilter(TagClickEventArgs tagClick);
        ICollection<TagViewModel> GetAvailableTags();
    }
}