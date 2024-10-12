using System;

namespace OpenMyGame.LoggerUnity.Configuration.Logger.Destinations.Platforms
{
    [Flags]
    public enum LoggerPlatform
    {
        None = 0,
        Editor = 1,
        Android = 2,
        Ios = 4
    }
}