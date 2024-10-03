﻿using System.Collections.Generic;
using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Tagging;

namespace OpenMyGame.LoggerUnity.Editor.TagsWindow.Models
{
    internal class TagsSource : ITagsSource
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
            var tagFilter = string.IsNullOrEmpty(tag) ? string.Empty : GetTagFilter(tag);
            _unityConsoleReflection.SetFilter(tagFilter);
        }

        public ICollection<LogTag> GetAvailableTags()
        {
            HasChanges = false;
            return _availableTags;
        }

        private void HandleMessageLogged(LogMessageLoggedEventArgs eventArgs)
        {
            if (eventArgs.Destination != LogDestinationsSupported.Debug)
            {
                return;
            }
            
            var logMessage = eventArgs.Message;
            
            if (logMessage.Tag is not null)
            {
                HasChanges = _availableTags.Add(logMessage.Tag);
            }
        }

        private static string GetTagFilter(string tag)
        {
            return Log.Logger.LogTagProvider.FormatTag(tag);
        }
    }
}