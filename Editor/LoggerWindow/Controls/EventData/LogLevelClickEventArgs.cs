namespace OpenMyGame.LoggerUnity.Editor.LoggerWindow.Controls.EventData
{
    public readonly struct LogLevelClickEventArgs
    {
        public LogLevelClickEventArgs(string logLevel, bool isActive)
        {
            LogLevel = logLevel;
            IsActive = isActive;
        }

        public string LogLevel { get; }
        public bool IsActive { get; }
    }
}