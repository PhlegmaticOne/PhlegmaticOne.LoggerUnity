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
            Log.MessageToDestinationLogged += HandleMessageLogged;
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

        private void HandleMessageLogged(LogMessageDestinationLoggedEventArgs eventArgs)
        {
            if (eventArgs.Destination != LogDestinationsSupported.Debug)
            {
                return;
            }
            
            var logMessage = eventArgs.Message;
            
            if (logMessage.HasTag())
            {
                var tagViewModel = TagViewModel.FromTag(logMessage.Tag);
                HasChanges = _availableTags.Add(tagViewModel);
            }
        }

        private static string GetTagFilter(in TagClickEventArgs tagClick)
        {
            var viewModel = tagClick.ViewModel;

            var tagWrapped = viewModel.HasColor
                ? UnityDebugStringColorizer.ColorizeString(viewModel.Tag, viewModel.Color)
                : viewModel.Tag;
            
            return Log.Logger.LogTagProvider.FormatTag(tagWrapped);
        }
    }
}