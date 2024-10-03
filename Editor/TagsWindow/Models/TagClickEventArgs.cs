namespace OpenMyGame.LoggerUnity.Editor.TagsWindow.Models
{
    internal readonly struct TagClickEventArgs
    {
        public static TagClickEventArgs Empty => new(string.Empty, false);
        
        public TagClickEventArgs(string tag, bool isActive)
        {
            Tag = tag;
            IsActive = isActive;
        }

        public string Tag { get; }
        public bool IsActive { get; }
    }
}