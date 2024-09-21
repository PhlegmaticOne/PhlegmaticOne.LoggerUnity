using System.Collections.Generic;
using OpenMyGame.LoggerUnity.Runtime;
using OpenMyGame.LoggerUnity.Runtime.Base;
using OpenMyGame.LoggerUnity.Runtime.Tagging;

namespace OpenMyGame.LoggerUnity.Editor.TagsWindow.Models
{
    public class TagsSource : ITagsSource
    {
        private readonly UnityConsoleReflection _unityConsoleReflection;
        private readonly HashSet<string> _availableTags;
        
        public TagsSource()
        {
            Log.MessageLogged += HandleMessageLogged;
            _unityConsoleReflection = new UnityConsoleReflection();
            _availableTags = new HashSet<string>();
        }

        public bool HasChanges { get; private set; }

        public void SetTagFilter(string tag)
        {
            var tagFilter = string.IsNullOrEmpty(tag) ? string.Empty : Log.WithTag(tag).Format();
            _unityConsoleReflection.SetFilter(tagFilter);
        }

        public ICollection<string> GetAvailableTags()
        {
            HasChanges = false;
            return _availableTags;
        }

        private void HandleMessageLogged(LogMessage logMessage)
        {
            if (logMessage.TryGetContextProperty<string>(LogWithTag.PropertyKey, out var tag))
            {
                HasChanges = _availableTags.Add(tag);
            }
        }
    }
}