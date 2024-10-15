namespace OpenMyGame.LoggerUnity.Editor.TagsWindow.Models
{
    internal readonly struct TagClickEventArgs
    {
        public static TagClickEventArgs Empty => new(null, false);
        
        public TagClickEventArgs(TagViewModel viewModel, bool isActive)
        {
            ViewModel = viewModel;
            IsActive = isActive;
        }

        public TagViewModel ViewModel { get; }
        public bool IsActive { get; }
    }
}