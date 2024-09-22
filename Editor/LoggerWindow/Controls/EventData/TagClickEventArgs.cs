using UnityEngine;

namespace OpenMyGame.LoggerUnity.Editor.LoggerWindow.Controls.EventData
{
    public readonly struct TagClickEventArgs
    {
        public static TagClickEventArgs Empty => new(string.Empty, Color.clear, false);
        public TagClickEventArgs(string tag, Color color, bool isActive)
        {
            Tag = tag;
            IsActive = isActive;
            Color = color;
        }

        public string Tag { get; }
        public Color Color { get; }
        public bool IsActive { get; }
    }
}