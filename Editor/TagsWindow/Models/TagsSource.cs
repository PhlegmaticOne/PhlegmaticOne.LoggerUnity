using System.Collections.Generic;
using OpenMyGame.LoggerUnity.Runtime;
using OpenMyGame.LoggerUnity.Runtime.Base;
using OpenMyGame.LoggerUnity.Runtime.Tagging;

namespace OpenMyGame.LoggerUnity.Editor.TagsWindow.Models
{
    public class TagsSource : ITagsSource
    {
        private readonly UnityConsoleReflection _unityConsoleReflection;
        private readonly HashSet<LogTag> _availableTags;
        
        public TagsSource()
        {
            Log.MessageLogged += HandleMessageLogged;
            _unityConsoleReflection = new UnityConsoleReflection();
            _availableTags = new HashSet<LogTag>();
        }

        public bool HasChanges { get; private set; }

        public void SetTagFilter(TagClickEventArgs tagClick)
        {
            var tag = !tagClick.IsActive ? string.Empty : tagClick.Tag;
            var tagFilter = string.IsNullOrEmpty(tag) ? string.Empty : Log.WithTag(tag).Format(tagClick.Color);
            _unityConsoleReflection.SetFilter(tagFilter);
        }

        public ICollection<LogTag> GetAvailableTags()
        {
            HasChanges = false;
            return _availableTags;
        }

        private void HandleMessageLogged(LogMessage logMessage)
        {
            if (logMessage.Tag is not null)
            {
                HasChanges = _availableTags.Add(logMessage.Tag);
            }
        }
    }
}