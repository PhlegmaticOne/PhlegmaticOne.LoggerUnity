namespace OpenMyGame.LoggerUnity.Editor.TagsWindow.Models
{
    public readonly struct TagClickEventArgs
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