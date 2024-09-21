using System.Collections.Generic;

namespace OpenMyGame.LoggerUnity.Editor.TagsWindow.Models
{
    public interface ITagsSource
    {
        bool HasChanges { get; }
        void SetTagFilter(string tag);
        ICollection<string> GetAvailableTags();
    }
}