namespace OpenMyGame.LoggerUnity.Editor.LoggerWindow.Controls.EventData
{
    public readonly struct TagClickEventArgs
    {
        public TagClickEventArgs(string tag, bool isActive)
        {
            Tag = tag;
            IsActive = isActive;
        }

        public string Tag { get; }
        public bool IsActive { get; }
    }
}