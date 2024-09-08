using System;
using UnityEngine.UIElements;

namespace OpenMyGame.LoggerUnity.Editor.LoggerWindow.Components
{
    public sealed class LoggerWindowToolbarButton : Button
    {
        public LoggerWindowToolbarButton(string text, Action onClick) : base(onClick)
        {
            this.text = text;
        }
    }
}