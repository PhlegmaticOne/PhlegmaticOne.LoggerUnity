using System.Collections.Generic;
using OpenMyGame.LoggerUnity.Tagging;

namespace OpenMyGame.LoggerUnity.Editor.TagsWindow.Models
{
    public interface ITagsSource
    {
        bool HasChanges { get; }
        void SetTagFilter(TagClickEventArgs tagClick);
        ICollection<LogTag> GetAvailableTags();
    }
}