using UnityEngine;

namespace OpenMyGame.LoggerUnity.Editor.Base.Styles
{
    internal static class LoggerWindowConstantStyles
    {
        internal static readonly Vector2 MinWindowSize = new(310, 500);
        internal const string WindowTitle = "Logger window";
        
        internal const int ToolbarHeight = 20;
        internal const int TooltipMinWidth = 40;

        internal static readonly Color ToolbarBackgroundColor = new(0.23f, 0.23f, 0.23f);
        internal static readonly Color BorderColor = new(0.13f, 0.13f, 0.13f);

        internal const int SearchBarWidth = 300;
        internal const int SearchBarMargin = 10;
        internal const string SearchBarTooltip = "Search filter...";

        internal const string ClearButtonText = "Clear";
        
        internal const int LogEntryMinHeight = 40;
    }
}