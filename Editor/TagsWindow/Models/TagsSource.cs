using System.Collections.Generic;
using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Destinations.UnityDebug.Colors.Helpers;

namespace OpenMyGame.LoggerUnity.Editor.TagsWindow.Models
{
    internal class TagsSource : ITagsSource
    {
        private readonly UnityConsoleReflection _unityConsoleReflection;
        private readonly HashSet<TagViewModel> _availableTags;
        
        public TagsSource()
        {
            Log.MessageLogged += HandleMessageLogged;
            _unityConsoleReflection = new UnityConsoleReflection();
            _availableTags = new HashSet<TagViewModel>();
        }

        public bool HasChanges { get; private set; }

        public void SetTagFilter(TagClickEventArgs tagClick)
        {
            var tag = !tagClick.IsActive ? string.Empty : tagClick.ViewModel.Tag;
            var tagFilter = string.IsNullOrEmpty(tag) ? string.Empty : GetTagFilter(tagClick);
            _unityConsoleReflection.SetFilter(tagFilter);
        }

        public ICollection<TagViewModel> GetAvailableTags()
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
                HasChanges = _availableTags.Add(TagViewModel.FromTag(logMessage.Tag));
            }
        }

        private static string GetTagFilter(in TagClickEventArgs tagClick)
        {
            var viewModel = tagClick.ViewModel;
            var tagColorized = UnityDebugColorWrapper.Colorize(viewModel.Tag, viewModel.Color);
            return Log.Logger.LogTagProvider.FormatTag(tagColorized);
        }
    }
}